using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDDTest
{
    public class RegisterPage
    {
        private readonly IWebDriver _driver;
        private const string URI = "https://auth.dotneterp.com.br/sign-up?app=arkiva";

        private IWebElement NameElement => _driver.FindElement(By.Name("name"));
        private IWebElement EmailElement => _driver.FindElement(By.Name("email"));
        private IWebElement PaswordElement => _driver.FindElement(By.Name("password"));
        private IWebElement ConfirmPaswordElement => _driver.FindElement(By.Name("confirmPassword"));

        private IWebElement BtnRegister => _driver.FindElement(By.Id("btnRegister"));


        public RegisterPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public void Navigate() => _driver.Navigate()
                .GoToUrl(URI);

        public void PopulateName(string name) => NameElement.SendKeys(name);

        public void PopulateEmail(string email) => EmailElement.SendKeys(email);

        public void PopulatePassword(string password) => PaswordElement.SendKeys(password);

        public void PopulateConfirmPassword(string confirmPassword) => ConfirmPaswordElement.SendKeys(confirmPassword);


        public void SubmitForm() => BtnRegister.Submit();


    }
}
