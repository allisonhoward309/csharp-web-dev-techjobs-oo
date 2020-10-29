using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTest
    {
            Employer acme = new Employer("ACME");
            Location desert = new Location("Desert");
            PositionType qualityControl = new PositionType("Quality control");
            CoreCompetency persistence = new CoreCompetency("Persistence");
            Job productTester;

     [TestInitialize]
     public void JobClass()
        {

            productTester = new Job("Product tester", acme, desert, qualityControl, persistence);
        }

        [TestMethod]
        public void TestSettingJobId()
        {
            Job idTest = new Job();
            Job idTest2 = new Job();
            Assert.IsFalse(idTest.Id == idTest2.Id);
            int difference = idTest2.Id - idTest.Id;
            Assert.AreEqual(1, difference);
        }
        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.AreEqual(1, productTester.Id);
            Assert.AreEqual("Product tester", productTester.Name);
            Assert.AreEqual(acme, productTester.EmployerName);
            Assert.AreEqual(desert, productTester.EmployerLocation);
            Assert.AreEqual(qualityControl, productTester.JobType);
            Assert.AreEqual(persistence, productTester.JobCoreCompetency);
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job productTester2 = new Job("Product tester", acme, desert, qualityControl, persistence);
            Assert.IsFalse(productTester.Equals(productTester2));
        }

        [TestMethod]
        public void TestJobsToString()
        {
            string sample = $"\nID: 4 \nName: Product tester \nEmployer: ACME " +
                $"\nLocation: Desert \nPosition Type: Quality control " +
                $"\nCore Competency: Persistence\n";
            Assert.AreEqual(sample, productTester.ToString());
        }
        [TestMethod]
        public void TestJobsToString1Empty()
        {
            productTester.EmployerName.Value = "";
            Assert.AreEqual("\nID: 5 \nName: Product tester " +
                "\nEmployer: Data not available \nLocation: Desert " +
                "\nPosition Type: Quality control \nCore Competency: Persistence\n", productTester.ToString());
        }
        [TestMethod]
        public void TestJobsToStringEmpty()
        {
            productTester.Name = "";
            productTester.EmployerName.Value = "";
            productTester.EmployerLocation.Value = "";
            productTester.JobType.Value = "";
            productTester.JobCoreCompetency.Value = "";
            Assert.AreEqual("OOPS! This job does not seem to exist.", productTester.ToString());
        }


    }
}
