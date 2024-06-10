using Enemy;
using PC;

namespace EnCreator {
    public static class EntityCreator {

        public static List<PChar> CreateFriends (int size, int minHP, int maxHP, int minDMG, int maxDMG, int minSPD, int maxSPD) {
            Random rnd = new Random();
            List<PChar> friends = new List<PChar>(size);
            for (int i = 0; i < size; ++i) {
                int hp = rnd.Next(minHP, maxHP + 1);
                int dmg = rnd.Next(minSPD, maxSPD + 1);
                int spd = rnd.Next(minDMG, maxDMG + 1);
                PChar friend = new PChar("F" + i, hp, dmg, spd);
                friends.Add(friend);
            }
            return friends;
        }

        public static List<EChar> CreateEnemies (int size, int minHP, int maxHP, int minDMG, int maxDMG, int minSPD, int maxSPD) {
            Random rnd = new Random();
            List<EChar> enemies = new List<EChar>(size);
            for (int i = 0; i < size; ++i) {
                int hp = rnd.Next(minHP, maxHP + 1);
                int dmg = rnd.Next(minSPD, maxSPD + 1);
                int spd = rnd.Next(minDMG, maxDMG + 1);
                EChar enemy = new EChar("E" + i, hp, dmg, spd);
                enemies.Add(enemy);
            }
            return enemies;
        }
    }
}