# Alien Shooter

## Зміст
<!--ts-->
   * [Про гру](#про-гру)
   * [Як грати](#як-грати)
   * [Керування персонажем](#керування-персонажем)
   * [Реалізація логіки](#реалізація-логіки)
   * [Онлайн гра](#онлайн-гра)
   * [Cкріншоти](#скріншоти)
<!--te-->

## Про гру
**Alien Shooter** - динамічний, сучасний та захоплюючий онлайн шутер для двох гравців. Кожен з гравців має змогу грати за одгого з декількох різноманітних персонажів з великими пушками, який намагається вбити свого супротивника. В процесі напруженої дуелі у гравця є можливість вільно літати по ігровому полю завдяки реактивному ранцю, ховатися за поставленими щитами і лікуватися за допомогую бонусів. Ви можете запитати: а де ж інопланетяни, якщо гра називається **Alien Shooter**. За сюжетом на Землю напали інопланетні розбійники, які можуть приймати форму оточуючих людей, тому в кожній дуелі один з вас обов'язково буде інопланетяненом, але ніхто не знає напевно, хто справжня людина👽

## Як грати
Після того, як ви зайшли у меню та натиснули кнопку Play, вам запропонують вибрати одногу з декількох різних персонажів. Вони відрізняються показниками здоров'я, швидкості та атакою, тому кожен гравець може підібрати собі персонажа під свій унікальний стиль ігри. Усі герої ідеально збалансовані, тому здобути перемогу можна тількі своєю майстерністю. Після вибору персонажа ви потрапляєте у лоббі, де вам запропонують створити або приєднатися до існуючої кімнати. Для того, щоб грати с другом, який створив кімнату, ви повинні бути підключенні до одного Wi-Fi та ввести у назву кімнати його локальну IP-адресу. Якщо ви все зробили правильно, ваші персонажі з'являються на ігровому бойовому полі. Ви переможете, якщо вб'єте свого супротивника. Використовуйте реактивний ранець для маневреності і несподіваних атак, щити для укриття від ворожого натиску та аптечки, які рандомно періодично генеруються на ігровому полі, щоб залікувати рани після напружених сутичок. Хай щастить!

## Керування персонажем
**Z** - стрільба  
**X** - поставити щит  
**Space** - стрибок  
🠜🠞 - рухатися

## Реалізація логіки
**Головний герой**  
Фізика та рух головного героя були реалізовані за допомогою стандартних засобів Unity у класах Player, PlayerController, PlayerJump. Анімація була намальована покадрово та реалызована у класі PlayerAnimation. Показниками здоров'я, швидкості та атаки зберігаються у класі Player та відповідно змінюються до обраного персонажу. Логіка підрахунку поточного здоров'я та перевірка героя на смерть знаходится у класі PlayerHealth.

**Стрільба**  
За генерацію кулі в правильному напрямку відповідає клас Weapon. Дальність польоту та дамаг кулі зберігається у класі Bullet.

**Бонуси здоров'я**  
Кожні 5-10 секунд на ігровому полі випадково генерується аптечка - HealthBonus, яка при контакті з гравцем надає йому 2 здоров'я. За випадкову генерацію відповідає клас HealthBonusManager, який у собі має список локацій, де з'яляється бонус через заданий проміжок часу.

**Щит**  
Персонаж має можливість закриватися за щитом (клас Shield), який вміє поглинати в себе частину дамагу, а потім знищується. За логіку генерації укриття відповідає клас PlayerShield.

**Кінець гри**  
Коли здоров'я одного з гравців опускається до 0, гра завершується. За відображення кінцевих результатів відповідає клас ResultsController, який генерує екран (класс Result) перемоги або програшу для кожного гравця.

## Онлайн гра
**Тут описать работу онлайна**

## Cкріншоти
<img src="https://github.com/VovaPylypenko/Game_Platformer/blob/master/Screenshots/screenshot1.jpeg">
<img src="https://github.com/VovaPylypenko/Game_Platformer/blob/master/Screenshots/screenshot2.jpeg">
