using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FSOClient.Scenes
{
    internal class LoginScene : BaseScene
    {
        private string _username = "";
        private string _password = "";

        public LoginScene(Game game) : base(game)
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
                Game.GraphicsDevice.Viewport.Width / 2f - 340 / 2,
                Game.GraphicsDevice.Viewport.Height / 2f - 305 / 2),
                ImGuiCond.Always);
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(340, 305), ImGuiCond.Always);

            ImGui.Begin("Login", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoTitleBar);

            ImGui.Spacing();

            float windowWidth = ImGui.GetWindowWidth();
            float itemWidth = 250f;
            float offset = (windowWidth - itemWidth - 16) / 2f; // 16 is padding adjustment

            // Email Label
            var emailTextSize = ImGui.CalcTextSize("Email:");
            ImGui.SetCursorPosX(offset + (itemWidth - emailTextSize.X) / 2f);
            ImGui.Text("Email:");

            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(itemWidth);
            ImGui.InputText("##Email", ref _username, 32);

            ImGui.Spacing();

            // Password Label
            var passwordTextSize = ImGui.CalcTextSize("Password:");
            ImGui.SetCursorPosX(offset + (itemWidth - passwordTextSize.X) / 2f);
            ImGui.Text("Password:");

            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(itemWidth);
            ImGui.InputText("##password", ref _password, 32, ImGuiInputTextFlags.Password);

            ImGui.Spacing();
            ImGui.Spacing();

            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(itemWidth);
            if (ImGui.Button("Login", new System.Numerics.Vector2(itemWidth, 40)))
            {
                // TODO: Implement login logic
                Game1.ScreenManager.ShowScreen(new CharacterSelectionScene(Game));
            }

            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(itemWidth);
            if (ImGui.Button("Back", new System.Numerics.Vector2(itemWidth, 40)))
            {
                Game1.ScreenManager.ShowScreen(new Menuscene(Game));
            }

            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(itemWidth);
            if (ImGui.Button("Forgot Password", new System.Numerics.Vector2(itemWidth, 40)))
            {
                Game1.ScreenManager.ShowScreen(new Menuscene(Game));
            }

            ImGui.End();
        }
    }
}
