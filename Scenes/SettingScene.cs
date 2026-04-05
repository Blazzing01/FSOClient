using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FSOClient.Scenes
{
    internal class SettingScene : BaseScene
    {
        private float _masterVolume = 0.8f;
        private float _musicVolume = 0.7f;
        private float _sfxVolume = 0.9f;
        private bool _fullscreen = false;

        public SettingScene(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }

        protected override void RenderImGui(GameTime gameTime)
        {
            ImGui.SetNextWindowPos(new System.Numerics.Vector2(
                Game.GraphicsDevice.Viewport.Width / 2f - 150,
                Game.GraphicsDevice.Viewport.Height / 2f - 120),
                ImGuiCond.Always);
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(430, 380), ImGuiCond.Always);

            ImGui.Begin("Settings", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoTitleBar);

            ImGui.Text("Game Settings");
            ImGui.Spacing();
            ImGui.Separator();
            ImGui.Spacing();

            ImGui.Text("Audio");
            ImGui.SliderFloat("Master Volume##master", ref _masterVolume, 0f, 1f);
            ImGui.SliderFloat("Music Volume##music", ref _musicVolume, 0f, 1f);
            ImGui.SliderFloat("SFX Volume##sfx", ref _sfxVolume, 0f, 1f);

            ImGui.Spacing();
            ImGui.Separator();
            ImGui.Spacing();

            ImGui.Text("Graphics");
            ImGui.Checkbox("Fullscreen", ref _fullscreen);

            ImGui.Spacing();
            ImGui.Spacing();

            if (ImGui.Button("Apply", new System.Numerics.Vector2(-1, 40)))
            {
                // TODO: Implement settings apply logic
            }

            if (ImGui.Button("Back", new System.Numerics.Vector2(-1, 40)))
            {
                Game1.ScreenManager.ShowScreen(new Menuscene(Game));
            }

            ImGui.End();
        }
    }
}
