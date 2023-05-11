using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest.DesingPatterns
{
    public class Meal
    {
        public string MainItem { get; set; }
        public string SideItem { get; set; }
        public string Drink { get; set; }

    }

    public interface IMealBuilder
    {
        void BuildMainItem();
        void BuildSideItem();
        void BuildDrink();
        void BuildMeal();
        Meal GetMeal();
    }

    public abstract class MealBuilder : IMealBuilder
    {
        protected Meal meal { get; set; }

        public MealBuilder()
        {
            meal = new Meal();
        }

        public abstract void BuildMainItem();
        public abstract void BuildSideItem();
        public void BuildDrink()
        {
            meal.Drink = "Drink Cup";
        }

        //Template pattern - specify the oder in the base class, derived class only provide the implementation but can't change the order

        public void BuildMeal() 
        {
            BuildMainItem();
            BuildSideItem();
            BuildDrink();
        }
        public Meal GetMeal()
        {
            BuildMeal();
            return meal;
        }
    }

    public class ChickenMealBuilder : MealBuilder
    {
        public override void BuildMainItem()
        {
            meal.MainItem = "Chicken Burger";
        }

        public override void BuildSideItem()
        {
            meal.SideItem = "Fries";
        }
    }

    public class VeggieMealBuilder : MealBuilder
    {
        public override void BuildMainItem()
        {
            meal.MainItem = "Veggie Burger";
        }

        public override void BuildSideItem()
        {
            meal.SideItem = "Fries";
        }
    }


    public class Cashier
    {
        private IMealBuilder mealBuilder { get; set; }
        public Meal Order(string mealtype)
        {
            switch (mealtype)   //Factory pattern - hiding the object construction from consumer
            {
                case "ChickenBurgerMeal":
                    mealBuilder = new ChickenMealBuilder();
                    break;
                case "VeggieBurgerMeal":
                    mealBuilder = new VeggieMealBuilder();
                    break;
            }
            var meal = mealBuilder.GetMeal();
            return meal;
        }

    }
}
