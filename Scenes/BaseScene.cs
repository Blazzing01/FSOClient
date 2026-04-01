using Microsoft.Xna.Framework;
using MonoGame.Extended.Screens;
using ImGuiNET;

namespace FSOClient.Scenes
{
    public class BaseScene : GameScreen
    {
        protected Game1 Game1 { get; private set; }

        public BaseScene(Game game) : base(game)
        {
            Game1 = game as Game1;
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            // Just call RenderImGui - Game1 handles BeginLayout/EndLayout
            RenderImGui(gameTime);
        }

        /// <summary>
        /// Override this method in derived scenes to render ImGui widgets
        /// </summary>
        protected virtual void RenderImGui(GameTime gameTime)
        {
        }
    }
}
