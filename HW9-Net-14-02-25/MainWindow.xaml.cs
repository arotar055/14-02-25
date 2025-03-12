using System.Reflection;
using System.Windows;
using interfaces;

namespace HW9_Net_14_02_25;

public partial class MainWindow : Window
{
    // Интерфейсные ссылки в DLL
    private IOpen _openHandler;
    private ISave _saveHandler;
    private IFont _fontHandler;
    private IColor _colorHandler;

    public MainWindow()
    {
        InitializeComponent();
        LoadDynamicAssemblies();
    }

    // Динамически загружаем сборки и привязываемся к нужным классам через интерфейсы
    private void LoadDynamicAssemblies()
    {
        // Загрузка "Открыть"
        Assembly openAssembly = Assembly.LoadFrom("open.dll");
        Type openType = openAssembly.GetType("Open.open_document");
        object openInstance = Activator.CreateInstance(openType);
        _openHandler = (IOpen)openInstance;

        // Загрузка "Сохранить"
        Assembly saveAssembly = Assembly.LoadFrom("save.dll");
        Type saveType = saveAssembly.GetType("Save.save_document");
        object saveInstance = Activator.CreateInstance(saveType);
        _saveHandler = (ISave)saveInstance;

        // Загрузка "Шрифт"
        Assembly fontAssembly = Assembly.LoadFrom("fonts.dll");
        Type fontType = fontAssembly.GetType("Fonts.font_select");
        object fontInstance = Activator.CreateInstance(fontType);
        _fontHandler = (IFont)fontInstance;

        // Загрузка "Цвет"
        Assembly colorAssembly = Assembly.LoadFrom("color.dll");
        Type colorType = colorAssembly.GetType("Color.color_select");
        object colorInstance = Activator.CreateInstance(colorType);
        _colorHandler = (IColor)colorInstance;
    }

    private void OnOpenMenuClick(object sender, RoutedEventArgs e)
    {
        _openHandler.open(Editor);
    }

    private void OnSaveMenuClick(object sender, RoutedEventArgs e)
    {
        _saveHandler.save(Editor);
    }

    private void OnFontMenuClick(object sender, RoutedEventArgs e)
    {
        _fontHandler.select_font(Editor);
    }

    private void OnColorMenuClick(object sender, RoutedEventArgs e)
    {
        _colorHandler.select_color(Editor);
    }
}
