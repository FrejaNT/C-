using System.ComponentModel;
using System.Data.Common;
using ICombatProfile;

namespace TL {
    public class TurnList {
        protected bool head;
        public IProfile profile;
        public int speed;

        public bool left;
        public TurnList next;
        public TurnList prev;

        public TurnList (IProfile profile, int speed, bool side) {
            head = true;
            this.profile = profile;
            this.speed = speed;
            next = this;
            prev = this;
            left = side;
        }
        private TurnList (IProfile profile, int speed, TurnList next, TurnList prev, bool side) {
            head = false;
            this.profile = profile;
            this.speed = speed;
            this.next = next;
            this.prev = prev;
            left = side;

        }

        public void Add (IProfile newProfile, int newSpeed, bool side) {
            AddRecursion(newProfile, newSpeed, this, side);
        }
        private void AddRecursion (IProfile newProfile, int newSpeed, TurnList first, bool side) {
            if (Object.ReferenceEquals(profile, newProfile)) return;
            if (speed < newSpeed) {
                TurnList temp = next;
                next = new TurnList (profile, speed, temp, this, side);
            }
            if (speed >= newSpeed && next.head == false) {
                next.AddRecursion(newProfile, newSpeed, first, side);
            }
            if (speed >= newSpeed && next.head == true) {
                next = new TurnList (newProfile, newSpeed, first, this, side);
                first.prev = next;
            }
        }

        private TurnList? Find (IProfile target) {
            return Find(target, this);
        }
        private TurnList? Find (IProfile target, TurnList start) {
            if (Object.ReferenceEquals(this, start)) return null;
            if (Object.ReferenceEquals(profile, target)) return this;

            return next.Find(target);
        }

        private TurnList FindUpdate (int newSpeed) {
            if (newSpeed < prev.speed && newSpeed > next.speed) return this;
            if (newSpeed < speed) return next.FindUpdate(newSpeed);
            
            if (newSpeed > speed) return prev.FindUpdate(newSpeed);
            
            return this;
        }
        public TurnList Delete (IProfile oldProfile) {
            return Remove(oldProfile, this) ?? this;
        }
        private TurnList? Remove (IProfile oldProfile, TurnList first) {
            TurnList? old = Find(oldProfile);
            if (old == null) return this;
            old.prev.next = old.next;
            old.next.prev = old.prev;
            if (old.head == true) {
                old.next.head = true;
                return old.next;
            }
            return first;
        }

        public TurnList Update (IProfile target, int newSpeed) {
            return Move(target, newSpeed, this) ?? this;
        }

        private TurnList? Move (IProfile target, int newSpeed, TurnList first) {
            TurnList? moved = Find(target);
            if (moved == null) return null;
            TurnList newPosition = FindUpdate(newSpeed);
            moved.speed = newSpeed;

            moved.prev.next = moved.next;
            moved.next.prev = moved.prev;

            if (newSpeed < newPosition.speed) {
                moved.next = newPosition.next;
                moved.prev = newPosition;

                newPosition.next = moved;
                newPosition.next.prev = moved;
            }
            if (newSpeed >= newPosition.speed) {
                moved.next = newPosition;
                moved.prev = newPosition.prev;

                newPosition.prev = moved;
                newPosition.prev.next = moved;

                if (newPosition.head == true) {
                    newPosition.head = false;
                    moved.head = true;
                    return moved;
                }
            }
            return first;
        }
        public void activateEvents (List<IProfile> friendlyTargets, List<IProfile> enemyTargets) {
            if (next.head == true) return;
            if (left == true) {
                profile.applyTurn(friendlyTargets, enemyTargets);
                next.activateEvents(friendlyTargets, enemyTargets);
            }
            else {
                profile.applyTurn(enemyTargets, friendlyTargets);
                next.activateEvents(friendlyTargets, enemyTargets);
            }
        }
    }
}