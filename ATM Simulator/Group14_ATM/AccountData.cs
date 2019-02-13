namespace Group14_ATM
{
    public class AccountData
    {
        private Account[] ac = new Account[3];
    
        public AccountData()
        {
            ac[0] = new Account(300, 1111, 111111);
            ac[1] = new Account(750, 2222, 222222);
            ac[2] = new Account(3000, 3333, 333333);
        }

        public Account[] getAccounts()
        {
            return ac;
        }
    }
}