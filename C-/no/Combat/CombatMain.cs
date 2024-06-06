using ICombatProfile;

namespace CombatMain {
    // Handles overall combat logic, manages and updates combat profiles.
    // Also produces combat packets.
    public class CombatEngine {
        private List<Profile> left;
        private List<Profile> right;

        public CombatEngine (List<Profile> left, List<Profile> right){
            this.left = left;
            this.right = right;
        }


    }
}