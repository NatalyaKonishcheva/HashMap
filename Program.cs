using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hash;


namespace Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            int RowCount = 20;
            HashMap<string, string> ConcertProgram = new HashMap<string, string>(RowCount);

            Console.WriteLine("Воспользуйтесь меню для управлениями номерами концерта");
            Console.WriteLine("МЕНЮ\n" +
                    "1 - Вывести содержимое концертной программы\n" +
                    "2 - Добавить номер\n" +
                    "3 - Удалить номер\n" +
                    "4 - Проверить существование номера(ключ)\n" +
                    "5 - Узнать участвует ли исполнитель в концерте\n" +
                    "6 - Вывести количество номеров(пар ключ-значение)\n" +
                    "7 - Проверить таблицу на пустоту\n" +
                    "8 - Узнать исполнителя по произведению\n" +
                    "9 - Очистить таблицу\n" +
                    "10 - Завершить\n");
            int act;
            do
            {
                string strAct = Console.ReadLine();
                if (!Int32.TryParse(strAct, out act))
                {
                    Console.WriteLine("Неверный формат ввода, попробуйте еще раз");
                }
                else
                {
                    switch (act)
                    {
                        case 1:
                            Console.WriteLine(ConcertProgram);
                            break;
                        case 2:
                            Console.WriteLine("Введите название номера(ключ)");
                            string Key2 = Console.ReadLine();
                            
                            Console.WriteLine("Введите имя исполнителя(значение)");
                            string Value2 = Console.ReadLine();

                            ConcertProgram.Put(Key2, Value2);
                            if(Key2 == "" || Value2 == "")
                                Console.WriteLine("Операция вставки была не выполнена, попробуйте снова");
                            else
                                Console.WriteLine("Операция вставки выполнена");
                            break;
                        case 3://test
                            Console.WriteLine("Введите название номера(ключ), который вы хотите удалить");
                            string Key3 = Console.ReadLine();
                            ConcertProgram.Remove(Key3);
                            Console.WriteLine("Удаление завершено");
                            break;
                        case 4:
                            Console.WriteLine("Введите название номера(ключ), который вы хотите проверить");
                            string Key4 = Console.ReadLine();
                            if(!ConcertProgram.ContainsKey(Key4))
                            {
                                Console.WriteLine($"Номер с названием {Key4} НЕ включен в концертную программу");
                                break;
                            }
                            Console.WriteLine($"Номер с названием {Key4} включен в концертную программу");
                            break;
                        case 5:
                            Console.WriteLine("Введите имя исполнителя(значение), которое вы хотите проверить");
                            string Value5 = Console.ReadLine();
                            if(ConcertProgram.ContainsValue(Value5))
                                Console.WriteLine($"Номер с названием {Value5} включен в концертную программу");
                            else
                                Console.WriteLine($"Номер с названием {Value5} НЕ включен в концертную программу");
                            break;
                        case 6:
                            Console.WriteLine($"В концертной программе {ConcertProgram.Count} номеров") ;
                            break;
                        case 7:
                            if (ConcertProgram.IsEmpty)
                                Console.WriteLine("В концертной программе нет номеров(таблица пуста)");
                            else
                                Console.WriteLine("В концертной программе есть номера(таблица не пуста)");
                            break;

                        case 8:
                            Console.WriteLine("Введите название номера(ключ)");
                            string Key8 = Console.ReadLine();
                            try
                            {
                                Console.WriteLine($"Исполнитель(значение) - {ConcertProgram[Key8]}");
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Ошибка: {ex.Message}");
                            }
                            break;
                        case 9:
                            ConcertProgram.Clear();
                            Console.WriteLine("Все номера удалены из программы");
                            break;
                        case 10:
                            act = 10;
                            break;
                    }
                }
            } while (act != 10);
        }
    }
}
