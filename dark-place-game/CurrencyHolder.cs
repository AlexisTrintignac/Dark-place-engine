using System;

namespace dark_place_game
{

    [System.Serializable]
    /// Une Exeption Custom
    public class NotEnoughtSpaceInCurrencyHolderExeption : System.Exception {}

    public class CantWithDrawMoreThanCurrentAmountExeption : Exception{}

    public class CantStoreMoreThanCurrentAmountExeption : Exception{}

    public class CurrencyHolder
    {
        public static readonly string CURRENCY_DEFAULT_NAME = "Unnamed";

        /// Le nom de la monnaie
        public string CurrencyName {
            get {return currencyName;}
            private set {
                currencyName = value;
            }
        }
        // Le champs interne de la property
        private string currencyName = CURRENCY_DEFAULT_NAME;

        /// Le montant actuel
        public int CurrentAmount {
            get {return currentAmount;}
            private set {
                currentAmount = value;
            }
        }
        // Le champs interne de la property
        private int currentAmount = 0;

        /// La contenance maximum du conteneur
        public int Capacity {
            get {return capacity;}
            private set {
                capacity = value;
            }
        }
        // Le champs interne de la property
        private int capacity = 0;

        public CurrencyHolder(string name,int capacity, int amount){
            if(amount < 0 || name == null || name == "" || name.Length < 4 || name.Length > 10 || capacity < 1){
                throw new System.ArgumentException("Argument invalide");
            }
            if(name[0]=='a' || name[0]=='A'){
                throw new System.ArgumentException("Argument invalide");
            }
            Capacity = capacity;
            CurrencyName = name;
            CurrentAmount = amount;
        }

        public bool IsFull() {
            if(this.CurrentAmount == this.Capacity){
                return true;
            }
            return false;
            
        }

        public bool IsEmpty() {
            if (this.CurrentAmount == 0){
                return true;
            }
            return false;
        }

        public void Store(int amount) {
            var amountCurrent = this.CurrentAmount + amount;
            if(amount < 0) {
                throw new CantStoreMoreThanCurrentAmountExeption();
            }
            if(amountCurrent > this.Capacity || amount == 0){
                throw new System.ArgumentException("Argument invalide");
            }else {
                this.CurrentAmount += amount;
            }
            
        }

        public void Withdraw(int amount) {
            var amountCurrent = this.CurrentAmount - amount;
            if(amount < 0){
                throw new CantWithDrawMoreThanCurrentAmountExeption();
            }
            if(amount == 0) {
                throw new System.ArgumentException("Argument invalide");
            }
            this.CurrentAmount -= amount;
        }
    }
}