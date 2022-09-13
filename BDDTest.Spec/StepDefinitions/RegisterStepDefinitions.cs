

namespace BDDTest.Spec.StepDefinitions
{

    [Binding]
    public sealed class RegisterStepDefinitions : IDisposable
    {
        private IWebDriver _driver;
        private RegisterPage _page;


        //[OneTimeSetUp]
        public RegisterStepDefinitions()
        {
            var options = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, options);
            _page = new RegisterPage(_driver);
        }


        [Given(@"Navegou para a página de cadastro")]
        public void GivenNavegouParaAPaginaDeCadastro()
        {
            _page.Navigate();
        }



        [Given(@"preencheu os dados do formulário")]
        public void PreencheuOsDadosDoFormulario()
        {
            _page.PopulateName("Humberto Brum");
            _page.PopulateEmail("brum.humberto@gmail.com");
            _page.PopulatePassword("123Mudar");
            _page.PopulateConfirmPassword("123Mudar");
        }


        [When(@"clicar no botão de criar conta")]
        public void QuandoClicarNoBotaoDeLogin()
        {
            _page.SubmitForm();
            System.Threading.Thread.Sleep(500);

            
        }

        [Then(@"mostrou erros de validação")]
        public void ThenMostrouErrosDeValidacao()
        {
            var matErrors = _driver.FindElements(By.ClassName("mat-error"));
            var err = (from i in matErrors select i.GetAttribute("innerHTML")).ToList();

            var hasErrorMessages = err.Any(i => i.Contains("Falta o CPF!"))
                && err.Any(i => i.Contains("Falta o Nome da Empresa!"))
                && err.Any(i => i.Contains("Falta o CNPJ!"));

            Assert.IsTrue(hasErrorMessages);
        }



        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

    }
}
