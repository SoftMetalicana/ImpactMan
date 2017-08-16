namespace ImpactMan.Models.TextWriterStrategies
{
    using ImpactMan.Interfaces.Models.TextWriterStrategies;

    public class LoginMenuStrategy : ITextWriterStrategy
    {
        public void Write()
        {
            this.textWriter.Write(this.userInputDetails.Name,
                new Vector2(MenuConstants.LoginMenuUsernameX,
                    MenuConstants.LoginMenuUsernameY),
                Color.Black);

            this.textWriter.Write(this.userInputDetails.Password,
                new Vector2(MenuConstants.LoginMenuPasswordX,
                    MenuConstants.LoginMenuPasswordY),
                Color.Black);

            this.textWriter.Write(this.errorMessage,
                new Vector2(MenuConstants.LoginMenuErrorMessageX,
                    MenuConstants.LoginMenuErrorMessageY),
                Color.Black);
        }
    }
}
