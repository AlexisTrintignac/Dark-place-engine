using System;
using Xunit;

namespace dark_place_game.tests
{

    /// Cette classe contient tout un ensemble de tests unitaires pour la classe CurrencyHolder
    public class CurrencyHolderTest
    {
        public static readonly int EXEMPLE_CAPACITE_VALIDE = 2748;
        public static readonly int EXEMPLE_CONTENANCE_INITIALE_VALIDE = 978;
        public static readonly string EXEMPLE_NOM_MONNAIE_VALIDE = "Brouzouf";

        [Fact]
        public void VraiShouldBeTrue()
        {
            var vrai = true;
            Assert.True(vrai, "Erreur, vrai vaut false. Le test est volontairement mal écrit, corrigez le.");
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf10ShouldContain10Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 10);
            var result = ch.CurrentAmount == 10;
            Assert.True(result);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf25ShouldContain25Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 25);
            var result = ch.CurrentAmount == 25;
            Assert.True(result);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf0ShouldContain0Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 0);
            var result = ch.CurrentAmount == 0;
            Assert.True(result);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNegativeContentThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, -10);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNullNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(null, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithEmptyNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder("", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void BrouzoufIsAValidCurrencyName()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Brouzouf
            var ch = new CurrencyHolder("Brouzouf", EXEMPLE_CAPACITE_VALIDE, 0);
            Assert.True(ch.CurrencyName == "Brouzouf");
        }

        [Fact]
        public void DollardIsAValidCurrencyName()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Dollard
            var ch = new CurrencyHolder("Dollard", EXEMPLE_CAPACITE_VALIDE, 0);
            Assert.True(ch.CurrencyName == "Dollard");
        }

        [Fact]
        public void TestPut10CurrencyInNonFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac a moité plein, il contient maintenant la bonne quantité de currency
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 500);
            ch.Store(10);
            Assert.True(ch.CurrentAmount == 510);
        }

        [Fact]
        public void TestPut10CurrencyInNearlyFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac quasiement plein, une exeption NotEnoughtSpaceInCurrencyHolderExeption est levée.
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 500, 490);
                ch.Store(20);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNameShorterThan4CharacterThrowExeption()
        {
            // A vous d'écrire un test qui doit échouer s'il es possible de créer un CurrencyHolder dont Le Nom De monnaie est inférieur a 4 lettres
            Action mauvaisAppel = () => new CurrencyHolder("EU", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void WithdrawMoreThanCurrentAmountInCurrencyHolderThrowExeption()
        {
            // A vous d'écrire un test qui vérifie que retirer (methode withdraw) une quantité negative de currency leve une exeption CantWithDrawNegativeCurrencyAmountExeption.
            // Astuce : dans ce cas prévu avant même de pouvoir compiler le test, vous allez être obligé de créer la classe CantWithDrawMoreThanCurrentAmountExeption (vous pouvez la mettre dans le meme fichier que CurrencyHolder)
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 500, 490);
                ch.Withdraw(-20);
            };
            Assert.Throws<CantWithDrawMoreThanCurrentAmountExeption>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNameBetween4And10CharacterThrowExeption()
        {
            // moins de 4 caractères
            Action mauvaisAppel1 = () => new CurrencyHolder("EU", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel1);
            // plus de 10 caractères
            Action mauvaisAppel2 = () => new CurrencyHolder("EUUZDBFBUIFFFI", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel2);
            Action mauvaisAppel3 = () => new CurrencyHolder("EUUZDBFBUIFF", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel3);
        }

        [Fact]
        public void StoreMoreThanCurrentAmountInCurrencyHolderThrowExeption()
        {
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 700, 490);
                ch.Store(-20);
            };
            Assert.Throws<CantStoreMoreThanCurrentAmountExeption>(mauvaisAppel);
        }

        [Fact]
        public void TestStore20CurrencyInNearlyFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac quasiement plein, une exeption NotEnoughtSpaceInCurrencyHolderExeption est levée.
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 500, 490);
                ch.Store(20);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CantStore0CurrencyThrowExeption()
        {
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 700, 490);
                ch.Store(0);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CantWithdraw0CurrencyThrowExeption()
        {
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 700, 490);
                ch.Withdraw(0);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CantCreateCurrencyHolderWithAThrowExeption()
        {
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder("Absdfggr", 700, 490);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CantCreateCurrencyHolderWithaThrowExeption()
        {
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder("abcsd", 700, 490);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CantCreateCurrencyHolderWith0CapacityThrowExeption()
        {
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder("Test", 0, 0);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CantCreateCurrencyHolderWith0NegativeCapacityThrowExeption()
        {
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder("Test", -5, 0);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void IsEmptyTrueTest()
        {
            var ch = new CurrencyHolder("Test", 500, 0);
            Assert.True(ch.IsEmpty());
        }

        [Fact]
        public void IsEmptyFalseTest()
        {
            var ch = new CurrencyHolder("Test", 500, 250);
            Assert.False(ch.IsEmpty());
        }

        [Fact]
        public void IsFullTrueTest()
        {
            var ch = new CurrencyHolder("Test", 500, 500);
            Assert.True(ch.IsFull());
            var sac = new CurrencyHolder("Test", 800, 800);
            Assert.True(sac.IsFull());
        }

        [Fact]
        public void IsFullFalseTest()
        {
            var ch = new CurrencyHolder("Test", 500, 499);
            Assert.False(ch.IsFull());
            var sac = new CurrencyHolder("Test", 800, 750);
            Assert.False(sac.IsFull());
        }
    }
}