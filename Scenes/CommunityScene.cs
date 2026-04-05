using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FSOClient.Scenes
{
    internal class CommunityScene : BaseScene
    {
        private int _selectedTab = 0;
        private string[] _tabs = { "Forums", "Players", "Guilds", "News" };

        public CommunityScene(Game game) : base(game)
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
                Game.GraphicsDevice.Viewport.Width / 2f - 200,
                Game.GraphicsDevice.Viewport.Height / 2f - 150),
                ImGuiCond.Always);
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(400, 300), ImGuiCond.Always);

            ImGui.Begin("Community", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoTitleBar);

            ImGui.Text("Community Hub");
            ImGui.Spacing();

            if (ImGui.Button("Forums", new System.Numerics.Vector2(-1, 35)))
            {
                _selectedTab = 0;
            }
            if (ImGui.Button("Players", new System.Numerics.Vector2(-1, 35)))
            {
                _selectedTab = 1;
            }
            if (ImGui.Button("Guilds", new System.Numerics.Vector2(-1, 35)))
            {
                _selectedTab = 2;
            }
            if (ImGui.Button("News", new System.Numerics.Vector2(-1, 35)))
            {
                _selectedTab = 3;
            }

            ImGui.Spacing();
            ImGui.Separator();
            ImGui.Spacing();

            switch (_selectedTab)
            {
                case 0:
                    ImGui.Text("Forums coming soon...");
                    break;
                case 1:
                    ImGui.Text("Online Players: 0");
                    break;
                case 2:
                    ImGui.Text("Join a Guild to see details");
                    break;
                case 3:
                    ImGui.Text("Latest news updates will appear here");
                    break;
            }

            ImGui.Spacing();
            ImGui.Spacing();

            if (ImGui.Button("Back", new System.Numerics.Vector2(-1, 40)))
            {
                Game1.ScreenManager.ShowScreen(new Menuscene(Game));
            }

            ImGui.End();
        }
    }
}
