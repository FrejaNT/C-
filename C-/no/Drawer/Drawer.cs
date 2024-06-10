using System.Drawing;
using CombatPacket;
using IEntity;
using BPacket;
using Enemy;
using PC;

namespace Drawer {
    public class DrawChar
    {
        public char Symbol { get; set; }
        public Point Position { get; set; }

        public DrawChar(Point position, char symbol) {
            Position = position;
            Symbol = symbol;
        }

        public void Draw() {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(Symbol);
        }

        public void Erase() {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(' ');
        }
    }

    public class DrawLine {
        public string Line { get; set; }
        public Point Position { get; set; }

        public DrawLine(Point position, string line) {
            Position = position;
            Line = line;
        }

        public void Draw() {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(Line);
        }
        public void ReDraw (string line) {
            Line = line;
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(Line);
        }

        public void Erase() {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write("");
        }

    }

    public class LogWriter {
        public List<DrawLine> drawLines;
        public Point LogPosition { get; set; }
        public int size;
        public int capacity;

        public LogWriter (Point logPosition, int capacity) {
            drawLines = new List<DrawLine>(capacity);
            LogPosition = logPosition;
            size = 0;

            for (int i = 0; i < capacity; ++i) {
                Point rowPosition = new Point(logPosition.X, logPosition.Y + i);
                DrawLine row = new DrawLine(rowPosition, "");
            }
        }

        public void writeLog (string newLine) {
            string line = newLine;
            string prev;
            foreach (DrawLine d in drawLines) {
                prev = d.Line;
                d.ReDraw(line);
                line = prev;
            }
        }
    }

    public class BattleRow {
        public string FriendName {get; set;}
        public DrawLine Friend {get; set;}
        public string EnemyName {get; set;}
        public DrawLine Enemy {get; set;}

        public BattleRow (string friendName, Point friend , string enemyName, Point enemy) {
            FriendName = friendName;
            Friend = new DrawLine(friend, friendName + " ");
            EnemyName = enemyName;
            Enemy = new DrawLine(enemy, enemyName + " ");
        }

        public void FriendTarget () {
            Friend.ReDraw(FriendName + "<");
        }

        public void FriendActor () {
            Friend.ReDraw(FriendName + ">");
        }
        public void FriendNeutral () {
            Friend.ReDraw(FriendName + " ");
        }
        public void FriendDeath () {
            Friend.Erase();
        }
        public void EnemyTarget () {
            Enemy.ReDraw(EnemyName + ">");
        }
        public void EnemyActor () {
            Enemy.ReDraw(EnemyName + ">");
        }
        public void EnemyNeutral () {
            Enemy.ReDraw(EnemyName + " ");
        }
        public void EnemyDeath () {
            Enemy.Erase();
        }
    }

    public class BattleWriter {
        public List<BattleRow> Rows {get; set;}
        public Point BattlePos {get; set;}
        public int distance {get; set;}
        private LogWriter log;
        private BattleRow? currentFriend;
        private BattleRow? currentEnemy;

        public BattleWriter (Point battlePos, int battleDistance, Point logPos, int logCapacity) {
            Rows = new List<BattleRow>();
            BattlePos = battlePos;
            distance = battleDistance;
            log = new LogWriter(logPos, logCapacity);
        }

        public void CreateBattle (List<PChar> friends, List<EChar> enemies) {
            int nrRows = int.Max(friends.Count(), enemies.Count());
            string friendName;
            string enemyName;
            BattleRow row;
            
            for (int i = 0; i < nrRows; ++i) {
                Point friendPos = new Point(BattlePos.X, BattlePos.Y - i);
                Point enemyPos = new Point(BattlePos.X + distance, BattlePos.Y - i);

                if (friends[i] == null) {
                    friendName = "";
                    enemyName = enemies[i].name;
            
                    row = new BattleRow(friendName, friendPos, enemyName, enemyPos);
                    Rows.Add(row);
                    continue;
                }
                if (enemies[i] == null) {
                    friendName = friends[i].name;
                    enemyName = "";
            
                    row = new BattleRow(friendName, friendPos, enemyName, enemyPos);
                    Rows.Add(row);
                    continue;
                }
                friendName = friends[i].name;
                enemyName = enemies[i].name;
            
                row = new BattleRow(friendName, friendPos, enemyName, enemyPos);
                Rows.Add(row);
            }
        }
        public void BattleUpdate (LinkedList<EventPacket> events) {
            string actorName;
            string targetName;

            foreach (EventPacket e in events) {
                actorName = e.Actor.name;

                foreach (BattleRow r in Rows) {
                    if (currentFriend != null) {
                        currentFriend.FriendNeutral();
                        currentFriend = null;
                    }
                    if (currentEnemy != null) {
                        currentEnemy.EnemyNeutral();
                        currentEnemy = null;
                    }
                    if (e.dead == true && actorName == r.FriendName) {
                        r.FriendDeath();
                        log.writeLog(e.Line);
                        currentFriend = r;
                        continue;
                    }
                    if (e.dead == true && actorName == r.EnemyName) {
                        r.EnemyDeath();
                        log.writeLog(e.Line);
                        currentFriend = r;
                        continue;
                    }
                    targetName = e.Target.name;
                    if (targetName == r.EnemyName) {
                        r.EnemyTarget();
                        currentEnemy = r;
                    }
                    if (targetName == r.FriendName) {
                        r.FriendTarget();
                        currentEnemy = r;
                    }
                    if (actorName == r.FriendName) {
                        r.FriendActor();
                        log.writeLog(e.Line);
                        currentFriend = r;
                        continue;
                    }
                    if (actorName == r.EnemyName) {
                        r.EnemyActor();
                        log.writeLog(e.Line);
                        currentFriend = r;
                        continue;
                    }
                }
            }
        }
    }

}