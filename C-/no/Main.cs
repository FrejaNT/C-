using System;
using Enemy;
using PC;
using CombatMain;
using CombatPacket;
using BPacket;
using EnCreator;
using CCreator;
using Drawer;
using System.Drawing;


namespace Game{
  public class GameTest {
    static void Main(string[] args) {
      Console.CursorVisible = false;

      int[] intArgs = Array.ConvertAll(args, int.Parse);

      Start(intArgs);
    }

    static void Start(int[] args) {
      GameStart gs = new GameStart(args[0], args[1], args[2], args[3], args[4],
       args[5], args[6], args[7], args[8], args[9], args[10], args[11], args[12], args[13]);
      gs.Start();
      run(gs);
    }
    static void run(GameStart gs) {
      bool done = false;


        while (!done) {
          var ch = Console.ReadKey(true).Key;
          if (ch == ConsoleKey.Q) break;
          if (ch == ConsoleKey.Spacebar) done = gs.Turn();       
        }
  } 

  public class GameStart {
    List<PChar> friends;
    List<EChar> enemies;
    CombatEngine engine;

    BattleWriter battleWriter;

    public GameStart (int battleXPos, int battleYPos, int logXPos,
                     int logYPos, int minHP, int maxHP, int minDMG, int maxDMG, int minSPD, int maxSPD,
                     int leftSize, int rightSize, int distance, int logCapacity) {
      friends = EntityCreator.CreateFriends(leftSize, minHP, maxHP, minDMG, maxDMG, minSPD, maxSPD);
      enemies = EntityCreator.CreateEnemies(rightSize, minHP, maxHP, minDMG, maxDMG, minSPD, maxSPD);
      engine = CombatCreator.CreateCombat(friends, enemies);

      battleWriter = new BattleWriter(new Point(battleXPos, battleYPos), distance, new Point(logXPos, logYPos), logCapacity);
    }

    public void Start() {
      battleWriter.CreateBattle(friends, enemies);
    }
    public bool Turn() {
      bool done = engine.startTurn();
      battleWriter.BattleUpdate(engine.packet.getLog());
      return done;
    }
      
  } 
}
}
