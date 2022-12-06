using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        heroRepository = new HeroRepository();
    }

    [Test]
    public void ConstructorShouldInitializeData()
    {
        Assert.IsNotNull(heroRepository.Heroes);
    }

    [Test]
    public void CreateShouldAddHeroesToACollection()
    {
        int expectedCount = 5;

        for (int i = 1; i <= expectedCount; i++)
        {
            Hero hero = new Hero($"Hero{i}", i * 2);
            heroRepository.Create(hero);
        }

        Assert.AreEqual(expectedCount, heroRepository.Heroes.Count);
    }

    [Test]
    public void CreateShouldReturnCorrectMessage()
    {
        string heroName = "Hero";
        int heroLevel = 5;
        Hero hero = new Hero(heroName, heroLevel);

        string expectedMessage = $"Successfully added hero {hero.Name} with level {hero.Level}";
        Assert.AreEqual(expectedMessage, heroRepository.Create(hero));
    }

    [Test]
    public void CreateShouldThrowExceptionIfHeroIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Create(null);
        });
    }

    [Test]
    public void CreateShouldThrowExceptionIfHeroAlreadyExists()
    {
        for (int i = 1; i <= 5; i++)
        {
            Hero hero = new Hero($"Hero{i}", i * 2);
            heroRepository.Create(hero);
        }

        Assert.Throws<InvalidOperationException>(() =>
        {
            Hero hero = new Hero("Hero3", 5);
            heroRepository.Create(hero);
        });
    }

    [Test]
    public void RemoveShouldReturnCorrectBoolean()
    {
        for (int i = 1; i <= 5; i++)
        {
            Hero hero = new Hero($"Hero{i}", i * 2);
            heroRepository.Create(hero);
        }

        Assert.AreEqual(true, heroRepository.Remove("Hero5"));
        Assert.AreEqual(false, heroRepository.Remove("Hero5"));
    }

    [TestCase("")]
    [TestCase("                ")]
    [TestCase(null)]
    public void RemoveShouldThrowExceptionIfNameIsNullOrWhiteSpace(string name)
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Remove(name);
        });
    }

    [Test]
    public void GetHeroWithHighestLevelShouldReturnCorrectHero()
    {
        List<Hero> heroes = new List<Hero>();

        for (int i = 1; i <= 5; i++)
        {
            Hero hero = new Hero($"Hero{i}", i * 2);
            heroRepository.Create(hero);
            heroes.Add(hero);
        }

        Assert.AreEqual(heroes.Last(), heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHeroShouldReturnCorrectHero()
    {
        List<Hero> heroes = new List<Hero>();

        for (int i = 1; i <= 5; i++)
        {
            Hero hero = new Hero($"Hero{i}", i * 2);
            heroRepository.Create(hero);
            heroes.Add(hero);
        }

        Hero expectedHero = heroes.FirstOrDefault(h => h.Name == "Hero3");
        Assert.AreEqual(expectedHero, heroRepository.GetHero("Hero3"));
    }
}