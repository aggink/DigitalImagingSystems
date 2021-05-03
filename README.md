# Оконное приложение "Работа с изображениями"
## Лаба 1. Возможности:
* Можно открывать любое число изображений.
* Для каждого изображения можно выбрать метод наложения, прозрачность, а также цветовые каналы, с которыми программа будет работать.
* Размер изображений может быть любым (изображения меньшего размера растягивается до размеров большего изображения при наложении друг на друга).
## Лаба 2. "Градационные преобразования и Гистограммы". Возможности:
1. Градационные преобразования:
* Динамическое изменение графика функции.
* Динамическое изменение изображения при изменении кривой.
* Интерполяция точек: линейная, квадратичная, кубическая, полином Ньютона, полином Лагранжа, кривая Безье.
2. Гистограмма:
* Гистограмма обновляется в режими реального времени при изменении изображения.
## Лаба 3. "Бинамиризация изображений". Возможности:
* Pеализованы методы: 'Гаврилова', Отсу, Ниблека, Сауволы, Вульфа, Брэдли-Рота.
* Входные значение для методов Ниблека, Сауволы, Вульфа, Брэдли-Рота задает пользователь (размер окна и чувствительность/усиление).
* Для методов Ниблека, Сауволы, Вульфа, Брэдли-Рота оптимизирован процесс подсчета суммы пикселей в окне за счет интегральной матрицы.
## Лаба 4. "Пространственная фильтрация". Возможности:
* Реализована линейная и медианная фильтрация.
* Размер матрицы может быть любым (квадратным, прямоугольным, но нечетным).
* Размер матрицы, а также задание самой матрицы свободно меняется в процессе работы программы.
* При выходе матрицы за границы изображания используются зеркалирование относительно краев.
* Медиана массива ищется алгоритмом quckselect (https://en.wikipedia.org/wiki/Quickselect).
* Возможность применения размытия по Гауссу.
* Быстрый расчет и заполнение ядра фильтра числами для размытия по Гауссу с произвольной сигмой.
