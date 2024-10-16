# Тестовое задание Mindbox 
## Задание 1
### Описание задачи
Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. Оцениваемые критерии:
* Юнит-тесты
* Легкость добавления других фигур
* Вычисление площади фигуры без знания типа фигуры в compile-time
* Проверку на то, является ли треугольник прямоугольным

### Юнит-тесты
Для тестирования разработанного решения были написаны тесты на базе NUnit. В написании тестов были соблюдены правила нейминга, порядка и минимализма.

### Легкость добавления других фигур
При написании тестового задания было принято решение создать интерфейс [IFigure](https://github.com/VictorKomshn/MindboxTest2024/blob/main/AreaCalc.Core/Abstract/IFigure.cs), который является базовым, и от которого наледуются все объекты типа "Фигура".
Также был реализован порождающий паттерн "Абстрактная фабрика", в виде интерфейса [IFigureFactory](https://github.com/VictorKomshn/MindboxTest2024/blob/main/AreaCalc.Core/Abstract/IFigureFactory.cs), который также является базовым для фабрик конкретных объектов.

### Вычисление площади фигуры без знания типа фигуры в compile-time
Благодаря использованию фабричного метода появляется возможность создания объектов без знания их типов в compile-time. Также реализован конструктор, который автоматически подбирает подходящую фабрику, реализованную в сборке, в соответствии с переданным названием фигуры.

### Проверка на то, является ли треугольник прямоугольным

Для создания фигур с возможностю наличия прямоугольных углов, был реализован дополнительный интерфейс, [IRightFigure](https://github.com/VictorKomshn/MindboxTest2024/blob/main/AreaCalc.Core/Abstract/IRightFigure.cs), содержащий метод проверки угла.

## Задание 2
### Описание задачи
В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Необходимо написать SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

Решение данной задачи расположено в файле [Task2.sql](https://github.com/VictorKomshn/MindboxTest2024/blob/main/Task2.sql).