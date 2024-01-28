using System;
using System.Collections.Generic;

class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public bool IsCompleted { get; set; }

    public Note(string title, string description, DateTime date)
    {
        Title = title;
        Description = description;
        Date = date;
        IsCompleted = false;
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }
}

class Program
{
    private static List<Note> notes = new List<Note>();

    static void Main()
    {
        CreateSampleNotes();

        int currentIndex = 0;
        while (true)
        {
            Console.Clear();

            ShowNoteTitle(currentIndex);
            Console.WriteLine();
            Console.WriteLine("Нажмите ВВОД для просмотра подробной информации о заметке.");
            Console.WriteLine("Используйте стрелки Влево и Вправо для переключения между заметками.");

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    currentIndex = ChangeDate(currentIndex, -1);
                    break;
                case ConsoleKey.RightArrow:
                    currentIndex = ChangeDate(currentIndex, 1);
                    break;
                case ConsoleKey.Enter:
                    ShowNoteDetails(notes[currentIndex]);
                    break;
            }
        }
    }

    private static void CreateSampleNotes()
    {

        notes.Add(new Note("Заметка 1", "Описание: TS vs VP", new DateTime(2023, 10, 6)));
        notes.Add(new Note("Заметка 2", "Описание: TS vs Tundra", new DateTime(2023, 9, 23)));
        notes.Add(new Note("Заметка 3", "Описание: Мая сигнатурка шаманчик связывай!", new DateTime(2023, 10, 13)));

    }

    private static void ShowNoteTitle(int currentIndex)
    {

        Console.WriteLine($"Заметка: {notes[currentIndex].Title}");
    }

    private static void ShowNoteDetails(Note note)
    {
        Console.Clear();
        Console.WriteLine($"Название: {note.Title}");
        Console.WriteLine($"Дата: {note.Date.ToShortDateString()}");
        Console.WriteLine($"Описание: {note.Description}");
        Console.WriteLine($"Статус: {(note.IsCompleted ? "Завершена" : "Не завершена")}");



        Console.WriteLine();
        Console.WriteLine("Нажмите ВВОД для возврата к меню...");
        Console.ReadLine();
    }

    private static int ChangeDate(int currentIndex, int offset)
    {
        int newIndex = currentIndex + offset;


        if (newIndex >= 0 && newIndex < notes.Count)
        {
            return newIndex;
        }

        if (newIndex < 0)
        {
            return notes.Count - 1;
        }

        return 0;
    }
}