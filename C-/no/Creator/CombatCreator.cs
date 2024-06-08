using CombatMain;
using CombatPacket;
using ICombatProfile;
using IEntity;
using EnemyProfile;
using Enemy;
using PlayerProfile;
using PC;
using BPacket;

namespace CCreator{
    public static class CombatCreator {
        public static CombatEngine CreateCombat(List<PChar> left, List<EChar> right){
            BasicPacket packet = new BasicPacket(left.ToList<Entity>(), right.ToList<Entity>());
            List<PCProfile> friends = Friends(left, packet);
            List<ECProfile> enemies = Enemies(right, packet);

            return new CombatEngine(friends.ToList<IProfile>(), enemies.ToList<IProfile>(), packet);
        }

        private static List<ECProfile> Enemies(List<EChar> entities, ICombatPacket packet) {
            List<ECProfile> profiles = new List<ECProfile>();
            foreach (Entity e in entities) profiles.Add(new ECProfile(e.name,e.maxHealth, e.speed, e.attackValue, packet));
            return profiles;
        }

        private static List<PCProfile> Friends(List<PChar> entities, ICombatPacket packet) {
            List<PCProfile> profiles = new List<PCProfile>();
            foreach (Entity e in entities) profiles.Add(new PCProfile(e.name,e.maxHealth, e.speed, e.attackValue, packet));
            return profiles;
        }
    }
}