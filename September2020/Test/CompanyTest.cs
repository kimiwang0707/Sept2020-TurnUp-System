using NUnit.Framework;
using September2020.Pages;
using September2020.Helpers;

namespace September2020.Test
{
    [TestFixture]
    [Parallelizable]
    class CompanyTest : CommonDriver
    {

        [Test]
        public void CreateCompanyTest()
        {
            HomePage homeObj = new HomePage();
            homeObj.NavigateToCompany(driver);

            CompanyPage companyObj = new CompanyPage();
            companyObj.CreateCompany(driver);
        }

        [Test]
        public void EditCompanyTest()
        {
            HomePage homeObj = new HomePage();
            homeObj.NavigateToCompany(driver);

            CompanyPage companyObj = new CompanyPage();
            companyObj.EditCompany(driver);

        }

        [Test]
        public void DeleteCompanyTest()
        {
            HomePage homeObj = new HomePage();
            homeObj.NavigateToCompany(driver);

            CompanyPage companyObj = new CompanyPage();
            companyObj.DeleteCompany(driver);
        }

    }
    
}
