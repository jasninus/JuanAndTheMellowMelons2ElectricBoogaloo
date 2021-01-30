namespace UnityEngine.Rendering.Universal
{
    public class PixellateUrp : ScriptableRendererFeature
    {
        [System.Serializable]
        public class PixellateSettings
        {
            public RenderPassEvent renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
            public Material material;
            [Range(0, 1)]
            public float Dencity = 0.0f;
        }

        public PixellateSettings settings = new PixellateSettings();
        PixellateUrpPass pixellateLwrpPass;

        public override void Create()
        {
            pixellateLwrpPass = new PixellateUrpPass(settings.renderPassEvent, settings.material, settings.Dencity, this.name);
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            pixellateLwrpPass.Setup(renderer.cameraColorTarget);
            renderer.EnqueuePass(pixellateLwrpPass);
        }
    }
}

