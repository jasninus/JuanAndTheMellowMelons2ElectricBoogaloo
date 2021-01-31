namespace UnityEngine.Rendering.Universal
{
    internal class PixellateUrpPass : ScriptableRenderPass
    {
        public Material material;

        private RenderTargetIdentifier source;
        private RenderTargetIdentifier tempCopy = new RenderTargetIdentifier(tempCopyString);

        readonly string tag;
        readonly float dencity;

        static readonly int dencityString = Shader.PropertyToID("_Dencity");
        static readonly int tempCopyString = Shader.PropertyToID("_TempCopy");

        float r;

        public PixellateUrpPass(RenderPassEvent renderPassEvent, Material material, float dencity, string tag)
        {
            this.renderPassEvent = renderPassEvent;
            this.material = material;
            this.dencity = dencity;
            this.tag = tag;
        }

        public void Setup(RenderTargetIdentifier source)
        {
            this.source = source;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (dencity > 0)
            {
                CommandBuffer cmd = CommandBufferPool.Get(tag);
                RenderTextureDescriptor opaqueDesc = renderingData.cameraData.cameraTargetDescriptor;
                opaqueDesc.depthBufferBits = 0;
                cmd.GetTemporaryRT(tempCopyString, opaqueDesc, FilterMode.Bilinear);
                cmd.CopyTexture(source, tempCopy);
                r = (float)Screen.width / Screen.height;
                Vector2 data = (r > 1 ? new Vector2(r, 1) : new Vector2(1, r));
                material.SetVector(dencityString, data * (150 - dencity * 140));
                cmd.Blit(tempCopy, source, material, 0);
                context.ExecuteCommandBuffer(cmd);
                CommandBufferPool.Release(cmd);
            }
        }

        public override void FrameCleanup(CommandBuffer cmd)
        {
            cmd.ReleaseTemporaryRT(tempCopyString);
        }
    }
}
