using ICombatProfile;
using TL;

namespace CombatMain {
    // Handles overall combat logic, manages and updates combat profiles.
    // Also produces combat packets.
    public class CombatEngine {
        private List<IProfile> left;
        private List<IProfile> right;

        private TurnList turnList;

        public CombatEngine (List<IProfile> left, List<IProfile> right){
            this.left = left;
            this.right = right;
            turnList = new TurnList(left[0], left[0].speed);

            foreach (IProfile p in left) turnList.Add(p, p.speed);
            foreach (IProfile p in right) turnList.Add(p,p.speed);
        }


    }
}