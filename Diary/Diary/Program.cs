using System;
using System.Text;
using System.IO;
using System.Collections.Generic; 

namespace Diary
{
    public struct Note
    {
        private int Count;
        private DateTime Time;
        private string Name_Note;
        private string Text_Note;
        private string Additionally_Text_Field;

        public Note(int Count,string Name_Note, string Text_Note, string Additionally_Text_Field) 
        {
            this.Count = Count;
            this.Time = DateTime.Now ;
            this.Name_Note = Name_Note ;
            this.Text_Note = Text_Note ;
            this.Additionally_Text_Field = Additionally_Text_Field;
        }
        public Note(int Count, DateTime Time, string Name_Note, string Text_Note, string Additionally_Text_Field)
        {
            this.Count = Count;
            this.Time = Time;
            this.Name_Note = Name_Note;
            this.Text_Note = Text_Note;
            this.Additionally_Text_Field = Additionally_Text_Field;
        }
        /// <summary>
        /// Метод,возвращающий запись дневника.
        /// </summary>
        /// <returns></returns>
        public string Print() 
        {
            return  Convert.ToString(this.Count) + "|" + Convert.ToString(this.Time) + "|" + this.Name_Note + "|" + this.Text_Note + "|" + this.Additionally_Text_Field;         
        }
        /// <summary>
        /// Метод,перезаписывающий запись.
        /// </summary>
        /// <param name="Name_Note">Новое имя записи.</param>
        /// <param name="Text_Note">Новый текст записи.</param>
        /// <param name="Additionally_Text_Field">Новый комментарий записи.</param>
        public void Rewrite(string Name_Note, string Text_Note, string Additionally_Text_Field)
        {
            this.Time = DateTime.Now;
            this.Name_Note = Name_Note;
            this.Text_Note = Text_Note;
            this.Additionally_Text_Field = Additionally_Text_Field;
        }
        public void Rewrite(int Count,string Name_Note, DateTime Time, string Text_Note, string Additionally_Text_Field)
        {
            this.Count = Count;
            this.Time = Time;
            this.Name_Note = Name_Note;
            this.Text_Note = Text_Note;
            this.Additionally_Text_Field = Additionally_Text_Field;
        }
    }
    public struct Diary
    {
        private List<Note> Data;
        public int Count;
        public Diary(int Count)
        {
            this.Count = 0;
            this.Data = new List<Note>(Count);
        }

        /// <summary>
        /// Метод, удаляющий все записи дневника.
        /// </summary>
        public void Delete_All_Notes()
        {
            for (int i = this.Count - 1; this.Count != 0; i--) 
            { 
                Data.RemoveAt(i);
                this.Count--;
            }
        }

        /// <summary>
        /// Метод,удаляющий запись в дневнике.
        /// </summary>
        /// <param name="index">Номер удаляемой записи.</param>
        public void Delete_Note(int index)
        {
            Data.RemoveAt(index);
            this.Count--;
        }

        /// <summary>
        /// Метод,создающий новую запись в дневнике.
        /// </summary>
        /// <param name="New_Note"></param>
        public void Create_New_Note(Note New_Note)
        {
            Data.Add(New_Note);
            this.Count++;
        }

        /// <summary>
        /// Метод,позволяющий перезаписать существующую запись в дневнике.
        /// </summary>
        /// <param name="index">Номер перезаписываемой записи.</param>
        /// <param name="Name_Note">Новое имя записи.</param>
        /// <param name="Text_Note">Новый текст записи.</param>
        /// <param name="Additionally_Text_Field">Новый комментарий записи.</param>
        public void Rewrite_Note(int index, string Name_Note, string Text_Note, string Additionally_Text_Field)
        {
            var data = Data[index];
            data.Rewrite(Name_Note, Text_Note, Additionally_Text_Field);
            Data[index] = data;
        }

        public void Rewrite_Note(int index,int Count,DateTime Time, string Name_Note, string Text_Note, string Additionally_Text_Field)
        {
            var data = Data[index];
            data.Rewrite(Count,Name_Note, Time, Text_Note, Additionally_Text_Field);
            Data[index] = data;
        }

        public string this[int index]
        {
            get { return this.Data[index].Print(); }
        }

    }
    class Program
    {
        static string[] Print_Another_Text(int Number) 
        {
            string[] Name = 
                { 
                "А.С.Пушкин",
                "Ф.М.Достоевский",
                "А.С.Грибоедов",
                "Л.Н.Толстой",
                "М.Ю.Лермонтов",
                };
            string[] Book =
                {
                "Осень",
                "Идиот",
                "Горе от ума",
                "Война и мир",
                "Баллада",
                };
            string[] Text_Part =
                {
                "\tОктябрь уж наступил — уж роща отряхает\n\t\t\t\t\t\t\t\t\tПоследние листы с нагих своих ветвей;\n\t\t\t\t\t\t\t\t\tДохнул осенний хлад — дорога промерзает.\n\t\t\t\t\t\t\t\t\tЖурча еще бежит за мельницу ручей,\n\t\t\t\t\t\t\t\t\tНо пруд уже застыл; сосед мой поспешает\n\t\t\t\t\t\t\t\t\tВ отъезжие поля с охотою своей,\n\t\t\t\t\t\t\t\t\tИ страждут озими от бешеной забавы,\n\t\t\t\t\t\t\t\t\tИ будит лай собак уснувшие дубравы.",
                "\tОб заклад готов биться, что так, — подхватил с чрезвычайно довольным видом красноносый чиновник,\n\t\t\t\t\t\t\t\t\t — и что дальнейшей поклажи в багажных вагонах не имеется, хотя бедность и не порок, чего опять-таки нельзя не заметить.",
                "\tСветает!.. Ах! как скоро ночь минула!\n\t\t\t\t\t\t\t\t\tВчера просилась спать — отказ.\n\t\t\t\t\t\t\t\t\t«Ждем друга». — Нужен глаз да глаз,\n\t\t\t\t\t\t\t\t\tНе спи, покудова не скатишься со стула.\n\t\t\t\t\t\t\t\t\tТеперь вот только что вздремнула,\n\t\t\t\t\t\t\t\t\tУж день!.. сказать им..",
                "— Нынче обедает у нас Шуберт, полковник Павлоградского гусарского полка. Он был в отпуску здесь и берет его с собой.\n\t\t\t\t\t\t\t\t\tЧто делать? — сказал граф, пожимая плечами и говоря шуточно о деле, которое, видимо, стоило ему много горя.",
                "\tВот мост! вот чугунные влево перилы\n\t\t\t\t\t\t\t\t\tБлестят от огня фонарей;\n\t\t\t\t\t\t\t\t\tДержись за них крепче, устала, нет силы!..\n\t\t\t\t\t\t\t\t\tВот дом — и звонок у дверей.",
                };
            string[] text = new string[3];
            text[0] = Name[Number]; text[1] = Book[Number]; text[2] = Text_Part[Number];
            return text;
        }
        /// <summary>
        /// Запись дневника в файл.
        /// </summary>
        static void To_File_Text(string Files_Path, string OutPut_File_Name, Diary My_Diary) 
        {
            string My_Diary_Notes = "";
            for (int i = 0; i < My_Diary.Count ; i++) 
            {
                My_Diary_Notes += My_Diary[i] + "\r\n";
            }
            File.WriteAllText(@$"{Files_Path}\{OutPut_File_Name}", My_Diary_Notes);
        }
        
        /// <summary>
        /// Чтение дневника из файла.
        /// </summary>
        static Diary From_File_Text(string Files_Path, string OutPut_File_Name) 
        {
            string[] Notes = File.ReadAllLines(@$"{Files_Path}\{OutPut_File_Name}");
            string[] Notes_Collums;
            Diary My_Diary = new Diary(0);
            for (int i = 0; i < Notes.Length; i++) 
            {
                Notes_Collums = Notes[i].Split("|");
                Note New_Note = new Note(Convert.ToInt32(Notes_Collums[0]), Convert.ToDateTime(Notes_Collums[1]), Notes_Collums[2], Notes_Collums[3], Notes_Collums[4]);
                My_Diary.Create_New_Note(New_Note);
            }
            return My_Diary;
        }
        /// <summary>
        /// Добавление записей одного дневника в другой.
        /// </summary>
        /// <param name="Files_Path">Путь к файлу добовляемого дневника.</param>
        /// <param name="OutPut_File_Name">Имя файла добавляемого дневника.</param>
        /// <param name="My_Diary">Исходный дневник, к которому необходимо добавить записи.</param>
        /// <returns></returns>
        static Diary From_File_Text_Add(string Files_Path, string OutPut_File_Name, Diary My_Diary)
        {
            string[] Notes = File.ReadAllLines(@$"{Files_Path}\{OutPut_File_Name}");
            string[] Notes_Collums;
            for (int i = 0; i < Notes.Length; i++)
            {
                Notes_Collums = Notes[i].Split(" ");
                Note New_Note = new Note(Convert.ToInt32(My_Diary.Count), Convert.ToDateTime(Notes_Collums[1] + " " + Notes_Collums[2]), Notes_Collums[3], Notes_Collums[4], Notes_Collums[5]);
                My_Diary.Create_New_Note(New_Note);
            }
            return My_Diary;
        }
        /// <summary>
        /// Сортировка записей.
        /// </summary>
        /// <param name="Choise_Number">Номер для последующей сортировки.</param>
        /// <param name="My_Diary">Дневник.</param>
        /// <returns></returns>
        static Diary Sort_Notes(int Choise_Number, Diary My_Diary) 
        {

            string[] text_note_1 = new string[5];
            string[] text_note_2 = new string[5];
            for (int i = 0; i < My_Diary.Count; i++)
            {
                for (int j = 0 ; j < My_Diary.Count - i - 1; j++) 
                {
                    text_note_1 = My_Diary[j].Split('|');
                    text_note_2 = My_Diary[j + 1].Split('|');
                    if (Choise_Number == 1)
                    {
                        if (Convert.ToDateTime(text_note_1[Choise_Number]) > Convert.ToDateTime(text_note_2[Choise_Number]))
                        {
                            My_Diary.Rewrite_Note(j, Convert.ToInt32(text_note_2[0]) , Convert.ToDateTime(text_note_2[1]), text_note_2[2], text_note_2[3], text_note_2[4]);
                            My_Diary.Rewrite_Note(j+1, Convert.ToInt32(text_note_1[0]) ,  Convert.ToDateTime(text_note_1[1]), text_note_1[2], text_note_1[3], text_note_1[4]);
                        }
                    }
                    if (Choise_Number != 1) 
                    {
                        if (Convert.ToInt32(text_note_1[Choise_Number][0]) > Convert.ToInt32(text_note_2[Choise_Number][0]))
                        {
                            My_Diary.Rewrite_Note(j, Convert.ToInt32(text_note_2[0]), Convert.ToDateTime(text_note_2[1]), text_note_2[2], text_note_2[3], text_note_2[4]);
                            My_Diary.Rewrite_Note(j+1, Convert.ToInt32(text_note_1[0]), Convert.ToDateTime(text_note_1[1]), text_note_1[2], text_note_1[3], text_note_1[4]);
                        }
                    }
                }
            }
            return My_Diary;
        }
        /// <summary>
        /// Отрисовка/рендеринг информации на экране.
        /// </summary>
        /// <param name="Info">Тип рендеринга</param>
        /// <param name="Data">Дневник</param>
        static void Display_Info_Render(string Info , Diary Data) 
        {
            string[] Fields;
            string Name_Diary = "Мой дневник.";
            string Collums = "Номер записи |    Дата записи    |  Название записи  |    Запись    |    Комментарий";
            string Diary_Info = "\n1 - Открыть/создать дневник. \n" +
                                "2 - Записать дневник в файл. \n" +             
                                "3 - Добавить записи из файла. \n" +            
                                "4 - Упорядочить записи. \n" +                  
                                "5 - Закрыть дневник. \n"; ;
            
            string Note_Info =  "\n1 - Добавить новую запись. \n" +
                                "2 - Перезаписать запись. \n" +
                                "3 - Удалить запись. \n" +
                                "4 - Удалить все записи. \n" +
                                "5 - Закончить записи в дневнике. Перейти к дневнику. \n";
            
            Console.Clear();
            Console.WindowWidth = 200;
            Console.SetCursorPosition((Console.WindowWidth - Name_Diary.Length) / 2 , 0); 
            Console.WriteLine(Name_Diary);
            Console.WriteLine(Collums);

            for (int i = 0; i < Data.Count; i++)
            {
                Fields = Data[i].Split("|");
                for (int j = 0; j < Fields.Length; j++)
                {
                    switch (j)
                    {
                        case 0:
                            Console.Write("      " + Fields[j]);
                            break;
                        case 1:
                            Console.Write("       " + Fields[j]);
                            break;
                        case 2:
                            Console.Write(" " + Fields[j]);
                            break;
                        case 3:
                            Console.Write("       " + Fields[j]);
                            break;
                        case 4:
                            Console.Write("  \t" + Fields[j]);
                            break;
                        case 5:
                            Console.Write("  \t" + Fields[j]);
                            break;
                    }
                }
                Console.WriteLine();
            }
            switch (Info) 
            {
                case "Diary":
                        Console.WriteLine(Diary_Info);
                        break;
                case "Note":
                        Console.WriteLine(Note_Info);
                        break;
                default:
                        Console.WriteLine("Упс, что-то пошло не так. Нажмите Enter что-бы продолжить."); Console.ReadKey();
                        System.Environment.Exit(0);
                        break;
            }
            
        }
        static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8; //Кодировка для MacOS и WinOS
            string Name_Note, Text_Note, Additionally_Text_Field, Files_Path, OutPut_File_Name;//Строки ввода данных и путь+имя файла.
            int Number;                     //Число, отвечающее за удаление или переписывание заметки(номер заметки).
            int Choise_Number = 0;          //Число, отвечающее за сортировку по выбранному полю.
            string answer = "5";            //Строка,отвечающая за выбор пользователя.
            bool key, exit;                 //Логические переменные,используемые в цикле на бесперебойную работу приложения и для перехода между экранами.
            Diary My_Diary = new Diary(0);  //Дневник, тип данных - лист.
            
            //Начальное заполнение дневника:
            for (int i = 0; i < 5 ; i++) 
            {
                Note New_Note = new Note(My_Diary.Count, Print_Another_Text(i)[0], Print_Another_Text(i)[1], Print_Another_Text(i)[2]);
                My_Diary.Create_New_Note(New_Note);
            }
            //Конец начального заполнения дневника.

            exit = false;
            while (exit != true) 
            {
                if (answer == "1")
                {
                    key = true;
                    while (key != false) 
                    {
                        Display_Info_Render("Note", My_Diary);
                        Console.Write("Выберите дальнейшее действие:");
                        answer = Console.ReadLine();
                        switch (answer)
                        {
                            case "1":   //Добавить новую запись.
                                        Console.Write("Введите название записи:");
                                        Name_Note = Console.ReadLine();
                                        Console.Write("Введите текст записи:");
                                        Text_Note = Console.ReadLine();
                                        Console.Write("Введите комментарий:");
                                        Additionally_Text_Field = Console.ReadLine();
                                        
                                        Note New_Note = new Note(My_Diary.Count , Name_Note, Text_Note, Additionally_Text_Field);
                                        My_Diary.Create_New_Note(New_Note);
                                        break;
                            
                            case "2":   //Перезаписать запись.
                                        Console.Write("Введите номер изменяемой записи:");
                                        Number = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Введите новое название записи:");
                                        Name_Note = Console.ReadLine();
                                        Console.Write("Введите новый текст записи:");
                                        Text_Note = Console.ReadLine();
                                        Console.Write("Введите новый комментарий:");
                                        Additionally_Text_Field = Console.ReadLine();
                                        
                                        My_Diary.Rewrite_Note(Number, Name_Note, Text_Note, Additionally_Text_Field);
                                        break;
                            
                            case "3":   //Удалить запись.
                                        Console.Write("Введите номер удаляемой записи:");
                                        Number = Convert.ToInt32(Console.ReadLine());
                                        
                                        My_Diary.Delete_Note(Number);
                                        break;

                            case "4":   //Удалить все записи.
                                        My_Diary.Delete_All_Notes();
                                        break;
                            
                            case "5":   //Закончить записи в дневнике.
                                        key = false;
                                        break;
                            
                            default:
                                        Console.WriteLine("Некорректное действие!");
                                        System.Threading.Thread.Sleep(2000);
                                        break;
                        }
                    }
                }
                if (answer == "5")
                {
                    key = true;
                    while (key != false) 
                    {
                        Display_Info_Render("Diary", My_Diary);
                        Console.Write("Выберите дальнейшее действие:");
                        answer = Console.ReadLine();
                        switch (answer)
                        {
                            case "1":   //Открыть дневник из файла. При отсутсвии файла создает пустой.
                                        Console.Write("Введите путь искомого дневника(*при пустом поле создается новый дневник):");
                                        Files_Path = Console.ReadLine();
                                        if (Files_Path != "")
                                        {
                                            Console.Write("Введите имя искомого дневника:");
                                            OutPut_File_Name = Console.ReadLine();
                                            My_Diary = From_File_Text(Files_Path, OutPut_File_Name);
                                        }
                                        else { My_Diary = new Diary(0); }
                                        
                                        key = false;
                                        break;
                            
                            case "2":   //Записать дневник в файл.
                                        Console.Write("Введите путь сохранения дневника(*при пустом поле сохраняет на диске С):"); 
                                        Files_Path = Console.ReadLine();
                                        if (Files_Path == ""){ Files_Path = "C:"; }
                                        
                                        Console.Write("Введите имя сохраняемого дневника:");
                                        OutPut_File_Name = Console.ReadLine();

                                        To_File_Text(Files_Path, OutPut_File_Name,My_Diary);
                                        break;
                            
                            case "3":   //Добавить записи из файла.
                                        Console.Write("Введите путь дополнительного дневника(*при пустом поле обращается к диску С):");
                                        Files_Path = Console.ReadLine();
                                        if (Files_Path == "") { Files_Path = "C:"; }

                                        Console.Write("Введите имя дополнительного дневника:");
                                        OutPut_File_Name = Console.ReadLine();

                                        My_Diary = From_File_Text_Add(Files_Path, OutPut_File_Name, My_Diary);
                                        break;
                            
                            case "4":   //Упорядочить записи.
                                        My_Diary = Sort_Notes(Choise_Number,My_Diary);
                                        Choise_Number++;
                                        
                                        if (Choise_Number == 5 ) { Choise_Number = 0; }
                                        break;
                            
                            case "5":   //Закрыть дневник.
                                        key = false;
                                        exit = true;
                                        break;
                            
                            default:
                                Console.WriteLine("Некорректное действие!");
                                System.Threading.Thread.Sleep(2000);
                                break;
                        }
                    }
                }
            }   
        }
    }
}
