input();

void input()
{
    Console.WriteLine("Введите количество операций, которые будут записаны:");
    int count_oper = Convert.ToInt32(Console.ReadLine());
    while (count_oper < 2 || count_oper > 40)
    {
        Console.WriteLine("Введите число между 2 и 40:");
        count_oper = Convert.ToInt32(Console.ReadLine());
    }

    Console.WriteLine("Начинайте вводить траты в формате: " +
        "(Название услуги или товара; Количество денег)");
    string[] m_uslug = new string[count_oper];
    int[] m_cost = new int[count_oper];
    string temp = "";
    string[] temp_m = new string[2];
    for (int i = 0; count_oper > i; i++)
    {
        temp = Console.ReadLine();
        temp_m = temp.Split("; ");
        m_uslug[i] = temp_m[0];
        m_cost[i] = Convert.ToInt32(temp_m[1]);
    }
}

