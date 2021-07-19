using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Ulaw.ApplicationProcessor.Enums;
using ULaw.ApplicationProcessor.Enums;

namespace ULaw.ApplicationProcessor.Tests
{

    [TestClass]
    public class ApplicationSubmissionTests
    {
        [TestMethod]
        public void ApplicationSubmissionWithFirstLawDegree()
        {
            var sut = CreateSut(DegreeGrade.First, DegreeSubject.Law);
            var emailHtml = sut.Process();
            emailHtml.Should().BeEquivalentTo(TestConstants.OfferEmailForFirstLawDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithFirstLawAndBusinessDegree()
        {
            var sut = CreateSut(DegreeGrade.First, DegreeSubject.LawAndBusiness);
            var emailHtml = sut.Process();
            emailHtml.Should().BeEquivalentTo(TestConstants.OfferEmailForFirstLawAndBusinessDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithFirstEnglishDegree()
        {
            var sut = CreateSut(DegreeGrade.First, DegreeSubject.English);
            var emailHtml = sut.Process();
            emailHtml.Should().BeEquivalentTo(TestConstants.FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoOneLawDegree()
        {
            var sut = CreateSut(DegreeGrade.TwoOne, DegreeSubject.Law);
            var emailHtml = sut.Process();
            emailHtml.Should().BeEquivalentTo(TestConstants.OfferEmailForTwoOneLawDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoOneMathsDegree()
        {
            var sut = CreateSut(DegreeGrade.TwoOne, DegreeSubject.Maths);
            var emailHtml = sut.Process();
            emailHtml.Should().BeEquivalentTo(TestConstants.FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoOneLawAndBusinessDegree()
        {
            var sut = CreateSut(DegreeGrade.TwoOne, DegreeSubject.LawAndBusiness);
            var emailHtml = sut.Process();
            emailHtml.Should().BeEquivalentTo(TestConstants.OfferEmailForTwoOneLawAndBusinessDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoTwoEnglishDegree()
        {
            var sut = CreateSut(DegreeGrade.TwoTwo, DegreeSubject.English);
            var emailHtml = sut.Process();
            emailHtml.Should().BeEquivalentTo(TestConstants.FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoTwoLawDegree()
        {
            var sut = CreateSut(DegreeGrade.TwoTwo, DegreeSubject.Law);
            var emailHtml = sut.Process();
            emailHtml.Should().BeEquivalentTo(TestConstants.FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithThirdDegree()
        {
            var sut = CreateSut(DegreeGrade.Third, DegreeSubject.Maths);

            var emailHtml = sut.Process();
            emailHtml.Should().BeEquivalentTo(TestConstants.RejectionEmailForAnyThirdDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionGetValues()
        {
            var expectedResult = new Application("Law",
                "ABC123",
                new DateTime(2019, 9, 22),
                "Mr",
                "Test",
                "Tester",
                new DateTime(1991, 08, 14),
                false)
            {
                DegreeGrade = DegreeGrade.Third,
                DegreeSubject = DegreeSubject.Maths
            };
            var sut = CreateSut(DegreeGrade.Third, DegreeSubject.Maths);

            sut.Should().BeEquivalentTo(expectedResult);
        }

        private Application CreateSut(DegreeGrade grade, DegreeSubject subject)
        {
            return new Application("Law",
                "ABC123",
                new DateTime(2019, 9, 22),
                "Mr",
                "Test",
                "Tester",
                new DateTime(1991, 08, 14),
                false)
            {
                DegreeGrade = grade,
                DegreeSubject = subject
            };
        }
    }

}
