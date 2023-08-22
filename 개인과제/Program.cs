namespace 개인과제;
internal class Program
{
    private static Character player;

    static void Main(string[] args)
    {
        GameDataSetting();
        DisplayGameIntro();
    }

    static void GameDataSetting()
    {
        // 캐릭터 정보 세팅
        player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

        // 아이템 정보 세팅
    }

    static void DisplayGameIntro()
    {
        Console.Clear();

        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("1. 상태보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        int input = CheckValidInput(1, 2);
        switch (input)
        {
            case 1:
                DisplayMyInfo();
                break;

            case 2:
                DisplayInventory();
                break;
        }
    }

    static void DisplayMyInfo()
    {
        Console.Clear();
        Console.WriteLine("[상태창]");
        Console.WriteLine();
        string attackText = $"공격력: {player.Atk}";
        if (player.EquippedItem == 2)
        {
            attackText += " \u001b[31m(+2)\u001b[0m"; // (+2)를 빨간색으로 표시
        }
        Console.WriteLine(attackText);

        string defenseText = $"방어력: {player.Def}";
        if (player.EquippedItem == 1)
        {
            defenseText += " \u001b[31m(+5)\u001b[0m"; // (+5)를 빨간색으로 표시
        }
        Console.WriteLine(defenseText);

        Console.WriteLine($"체력 : {player.Hp}");
        Console.WriteLine($"Gold : {player.Gold} G");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");

        int input = CheckValidInput(0, 0);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
        }
    }

    static void DisplayInventory()
    {
        Console.Clear();
        Console.WriteLine("[인벤토리]");
        Console.WriteLine("보유 중인 아이템");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");
        Console.WriteLine("-" + (player.EquippedItem == 1 ? "\u001b[31m[E] \u001b[0m" : "") + "무쇠갑옷 | 방어력 +5");
        Console.WriteLine("-" + (player.EquippedItem == 2 ? "\u001b[31m[E] \u001b[0m" : "") + "낡은 검 | 공격력 +2");
        Console.WriteLine();
        Console.WriteLine("1. 장착관리");
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        int input = CheckValidInput(0, 1);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
            case 1:
                DisplayInventory_Item();
                break;
        }
    }
    static void DisplayInventory_Item()
    {
        Console.Clear();
        Console.WriteLine("[인벤토리 - 장착관리]");
        Console.WriteLine("보유 중인 아이템");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");
        Console.WriteLine("1." + (player.EquippedItem == 1 ? "\u001b[31m[E] \u001b[0m" : "") + "무쇠갑옷 | 방어력 +5");
        Console.WriteLine("2." + (player.EquippedItem == 2 ? "\u001b[31m[E] \u001b[0m" : "") + "낡은 검 | 공격력 +2");
        Console.WriteLine();
        Console.WriteLine("0. 뒤로가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        int input = CheckValidInput(0, 2);
        switch (input)
        {
            case 0:
                DisplayInventory();
                break;
            case 1:
                EquipItem(1);
                break;
            case 2:
                EquipItem(2);
                break;
        }
    }
    static void EquipItem(int itemNumber)
    {
        player.EquippedItem = itemNumber;
        Console.WriteLine("아이템이 장착되었습니다.");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        int input = CheckValidInput(0, 0);
        if (input == 0)
        {
            DisplayInventory();
        }
        DisplayMyInfo(); // 아이템 장착 후 상태를 다시 보여줌
    }


    static int CheckValidInput(int min, int max)
    {
        while (true)
        {
            string input = Console.ReadLine();

            bool parseSuccess = int.TryParse(input, out var ret);
            if (parseSuccess)
            {
                if (ret >= min && ret <= max)
                    return ret;
            }

            Console.WriteLine("잘못된 입력입니다.");
        }
    }
}


public class Character
{
    public int EquippedItem { get; set; }


    public int EquippedItemBonus
    {
        get
        {
            switch (EquippedItem)
            {
                case 1:
                    return 5; // 무쇠갑옷의 방어력 보너스
                case 2:
                    return 2; // 낡은 검의 공격력 보너스
                default:
                    return 0; // 장착된 아이템 없음
            }
        }
    }

    public string Name { get; }
    public string Job { get; }
    public int Level { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }
    public int Gold { get; }

    public Character(string name, string job, int level, int atk, int def, int hp, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Gold = gold;

        EquippedItem = 0;
    }
}
//개인과제 확인