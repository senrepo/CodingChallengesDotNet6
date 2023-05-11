using CodingChallengesTest.DesingPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest
{
    [TestFixture]
    public class DesignPatternChallenge
    {
        [Test]
        public void TestBuilderPattern()
        {
            var cashier = new Cashier();
            var vegMeal = cashier.Order("VeggieBurgerMeal");
            var nonVegMeal = cashier.Order("ChickenBurgerMeal");

            var vegmealPlate = $"MainItem:{vegMeal.MainItem}, SideItem:{vegMeal.SideItem}, Drink: {vegMeal.Drink}";
            var nonVegmealPlate = $"MainItem:{nonVegMeal.MainItem}, SideItem:{nonVegMeal.SideItem}, Drink: {nonVegMeal.Drink}";
        }

    }
}
