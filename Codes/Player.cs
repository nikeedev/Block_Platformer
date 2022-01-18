using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace TopDown_Block.Codes
{
    public class Player
    {
        Texture2D texture;
        Vector2 position;

        Vector2 velocity;

        bool hasJumped;


        public Player(Texture2D newTexture, Vector2 newPosition)
        {
            this.texture = newTexture;
            this.position = newPosition;
            hasJumped = true;
        }


        public void Update(GameTime gameTime)
        {
            position += velocity;
            KeyboardState k = Keyboard.GetState();


            if (k.IsKeyDown(Keys.Right)) velocity.X = 5f;
            else if (k.IsKeyDown(Keys.Left)) velocity.X = -5f;
            else velocity.X = 0f;

            if (k.IsKeyDown(Keys.Up) && !hasJumped)
            {
                position.Y -= 10f;
                velocity.Y = -5f;
                hasJumped = true;
            }

            if (hasJumped)
            {
                float i = 1f;
                velocity.Y += 0.15f * i;
            }

            if (position.Y + texture.Height >= 460)
            {
                hasJumped = false;
            }
            
            if (!hasJumped)
            {
                velocity.Y = 0f;
            }


        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.position, Color.White);
        }



    }
}
