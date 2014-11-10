using System.Collections.Generic;
using Library_CourseWorkDB.Models;

namespace Library_CourseWorkDB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library_CourseWorkDB.Models.HomeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Library_CourseWorkDB.Models.HomeContext context)
        {
            List<Author> authors = new List<Author>
            {
                new Author { Name = "Матвей", LastName = "Берман", SecondName = "Давыдович" },
                new Author { Name = "Борис", LastName = "Демидович", SecondName = "Павлович" },
                new Author { Name = "Джефри", LastName = "Рихтер", SecondName = null }
            };
            authors.ForEach(a => context.Authors.AddOrUpdate(t => t.LastName, a));
            context.SaveChanges();


            List<Status> statuses = new List<Status> {
                new Status { Name = "available" },
                new Status { Name = "reading room" },
                new Status { Name = "given away" }
                };
            statuses.ForEach(s => context.Statuses.AddOrUpdate(t => t.Name, s));
            context.SaveChanges();

            List<UDC> UDCs = new List<UDC>
            {
                new UDC{ Code = "0", Description = "Загальний відділ"},
                    new UDC{ Code = "00", Description = "Загальні питання науки та культури"},
                        new UDC{ Code = "001", Description = "Наука та знання в цілому. Організація розумової праці"},
                            new UDC{ Code = "001.1", Description = "Загальні уявлення про науку"},
                            new UDC{ Code = "001.2", Description = "Взаємозв'язок між різними галузями науки"},
                            new UDC{ Code = "001.3", Description = "Значення науки"},
                            new UDC{ Code = "001.4", Description = "Спеціальна термінологія. Наукова номенклатура"},
                            new UDC{ Code = "001.5", Description = "Наукові теорії. Гіпотези. Системи"},
                            new UDC{ Code = "001.6", Description = "Закони науки"},
                            new UDC{ Code = "001.8", Description = "Методологія"},
                            new UDC{ Code = "001.9", Description = "Розповсюдження знань і псевдознань"},
                        new UDC{ Code = "002", Description = "Документація. Книги. Письменництво. Авторство"},
                        new UDC{ Code = "003", Description = "Системи письма та писемності"},
                        new UDC{ Code = "004", Description = "Комп'ютерна наука та технологія. Застосування комп'ютера"},
                            new UDC{ Code = "004.2", Description = "Комп'ютерна архітектура"},
                            new UDC{ Code = "004.3", Description = "Апаратне забезпечення комп'ютерів"},
                            new UDC{ Code = "004.4", Description = "Програмне забезпечення"},
                            new UDC{ Code = "004.5", Description = "Взаємодія людини і комп'ютера. Інтерфейс користувача"},
                            new UDC{ Code = "004.6", Description = "Дані"},
                            new UDC{ Code = "004.7", Description = "Комп'ютерні мережі"},
                            new UDC{ Code = "004.8", Description = "Штучний інтелект"},
                            new UDC{ Code = "004.9", Description = "Прикладна техніка, що базується на комп'ютерних системах. Прикладні інформаційні системи"},
                        new UDC{ Code = "006", Description = "Стандартизація та стандарти"},
                        new UDC{ Code = "008", Description = "Цивілізація. Культура. Прогрес"},
                    new UDC{ Code = "01", Description = "Бібліографія та бібліографічні покажчики. Каталоги"},
                        new UDC{ Code = "011", Description = "Універсальні та загальні бібліографії"},
                        new UDC{ Code = "012", Description = "Бібліографії творів окремих авторів і окремих творів невідомих авторів"},
                        new UDC{ Code = "013", Description = "Бібліографії певних груп (колективів) авторів"},
                        new UDC{ Code = "014", Description = "Бібліографія праць за певними особливостями (анонімних праць, праць під псевдонімом тощо)"},
                        new UDC{ Code = "015", Description = "Бібліографії за місцем видання"},
                        new UDC{ Code = "016", Description = "Галузеві бібліографії"},
                        new UDC{ Code = "017", Description = "Каталоги в цілому. Реальні каталоги"},
                        new UDC{ Code = "018", Description = "Каталоги формальні"},
                        new UDC{ Code = "019", Description = "Словникові або перехресні каталоги"},
                    new UDC{ Code = "02", Description = "Бібліотечна справа"},
                        new UDC{ Code = "021", Description = "Функції, значення, цінність, розвиток бібліотек"},
                        new UDC{ Code = "022", Description = "Бібліотечне приміщення, будівля та прилеглі території. Обладнання"},
                        new UDC{ Code = "023", Description = "Організація роботи бібліотек. Кадри. Персонал бібліотек"},
                        new UDC{ Code = "024", Description = "Відносини з читачами (обслуговування). Регулювання користуванням бібліотекою"},
                        new UDC{ Code = "025", Description = "Адміністративні відділи бібліотеки (формування фондів, довідково-бібліографічна робота, книговидача)"},
                        new UDC{ Code = "026", Description = "Галузеві та спеціальні бібліотеки"},
                        new UDC{ Code = "027", Description = "Універсальні бібліотеки"},
                        new UDC{ Code = "028", Description = "Читання (психологія читання, методи та техніка читання)"},
                    new UDC{ Code = "030", Description = "Довідкові видання загального типу (енциклопедії, словники)"},
                    new UDC{ Code = "050", Description = "Серійні публікації. Періодика (щорічники, альманахи, календарі)"},
                    new UDC{ Code = "06", Description = "Організація та інші типи об'єднання (співробітництва)"},
                    new UDC{ Code = "070", Description = "Газети. Преса"},
                    new UDC{ Code = "08", Description = "Видання змішаного змісту. Праці. Збірники"},
                        new UDC{ Code = "087.5", Description = "Науково-популярна література для дітей"},
                    new UDC{ Code = "09", Description = "Рукописи. Раритети та рідкісні видання"},
                        new UDC{ Code = "091", Description = "Рукописи"},
                        new UDC{ Code = "092", Description = "Ксилографічні книги"},
                        new UDC{ Code = "093", Description = "Інкунабули"},
                        new UDC{ Code = "094", Description = "Інші видання, надруковані особливим, оригінальним способом"},
                        new UDC{ Code = "095", Description = "Книги з незвичайними палітурками"},
                        new UDC{ Code = "096", Description = "Книги з видатними ілюстраціями або використаними цінними матеріалами"},
                        new UDC{ Code = "097", Description = "Книги зі знаками власників"},
                        new UDC{ Code = "098", Description = "Рідкі види книг з примітними характеристиками"},
                        new UDC{ Code = "099", Description = "Інші книги з видатними зовнішніми ознаками. Рідкісні, антикварні книги"},

                new UDC{ Code = "1", Description = "Філософія. Психологія"},
                    new UDC{ Code = "101", Description = "Сутність і роль філософії"},
                    new UDC{ Code = "11", Description = "Метафізика"},
                    new UDC{ Code = "12", Description = "Окремі проблеми та категорії філософії"},
                    new UDC{ Code = "13", Description = "Філософія розуму та духу. Метафізика духовного життя"},
                    new UDC{ Code = "14", Description = "Філософські системи та погляди"},
                    new UDC{ Code = "159.9", Description = "Психологія"},
                    new UDC{ Code = "16", Description = "Логіка. Епістемологія. Теорія пізнання. Методологія логіки"},
                    new UDC{ Code = "17", Description = "Філософія моралі. Етика. Практична філософія"},

                new UDC{ Code = "2", Description = "Релігія. Теологія (богослов'я)"},
                    new UDC{ Code = "21", Description = "Природна теологія. Теодицея. Бог. Раціональна теологія. Релігійна філософія"},
                    new UDC{ Code = "22", Description = "Біблія. Святе письмо"},
                    new UDC{ Code = "23", Description = "Догматична теологія"},
                    new UDC{ Code = "24", Description = "Практична теологія"},
                    new UDC{ Code = "25", Description = "Пасторська теологія (богослов'я)"},
                    new UDC{ Code = "26", Description = "Християнська церква в цілому"},
                    new UDC{ Code = "27", Description = "Загальна історія християнської церкви"},
                    new UDC{ Code = "28", Description = "Християнські церкви, секти, деномінації"},
                    new UDC{ Code = "29", Description = "Нехристиянські релігії"},

                new UDC{ Code = "3", Description = "Суспільні науки"},
                    new UDC{ Code = "30", Description = "Теорія, методологія та методи суспільних наук. Соціографія"},

                    new UDC{ Code = "31", Description = "Демографія, соціологія, статистика"},
                        new UDC{ Code = "311", Description = "Статистика як наука. Теорія статистики"},
                        new UDC{ Code = "314", Description = "Демографія. Вивчення народонаселення"},
                        new UDC{ Code = "316", Description = "Соціологія"},

                    new UDC{ Code = "32", Description = "Політика"},
                        new UDC{ Code = "321", Description = "Форми політичної організації. Держава як політична влада"},
                        new UDC{ Code = "322", Description = "Відносини між церквою та державою. Політика стосовно релігії. Церковна політика"},
                        new UDC{ Code = "323", Description = "Внутрішні справи. Внутрішня політика"},
                        new UDC{ Code = "324", Description = "Вибори. Плебісцити. Референдуми. Виборчі компанії. Корупція, зловживання під час виборів. Результати виборів"},
                        new UDC{ Code = "325", Description = "ідкриття нових територій. Колонізація"},
                        new UDC{ Code = "326", Description = "Рабство"},
                        new UDC{ Code = "327", Description = "Міжнародні зв'язки. Світова політика. Міжнародні справи. Зовнішня політика"},
                        new UDC{ Code = "328", Description = "Парламенти. Представництво народу. Уряди"},
                        new UDC{ Code = "329", Description = "Політичні партії та рухи"},

                    new UDC{ Code = "33", Description = "Економіка. Економічна наука"},
                        new UDC{ Code = "330", Description = "Економіка в цілому"},
                        new UDC{ Code = "331", Description = "Праця. Працевлаштування. Робота. Економіка праці. Організація праці"},
                        new UDC{ Code = "332", Description = "Регіональна економіка. Територіальна економіка. Економіка землі. Економіка житла"},
                        new UDC{ Code = "334", Description = "Форми організації та співробітництва в економіці"},
                        new UDC{ Code = "336", Description = "Фінанси"},
                        new UDC{ Code = "338", Description = "Економічне становище. Економічна політика. Управління та планування в економіці. Виробництво. Послуги. Ціни"},
                        new UDC{ Code = "339", Description = "Торгівля. Міжнародні економічні відносини. Світова економіка"},
                            new UDC{ Code = "339.1", Description = "Загальні питання торгівлі. Ринок"},
                            new UDC{ Code = "339.3", Description = "Внутрішня торгівля"},
                            new UDC{ Code = "339.5", Description = "Зовнішня торгівля. Міжнародна торгівля"},
                            new UDC{ Code = "339.7", Description = "Міжнародні фінанси"},
                            new UDC{ Code = "339.9", Description = "Міжнародна економіка в цілому. Міжнародні економічні зв'язки. Світове господарство"},

                    new UDC{ Code = "34", Description = "Право. Юриспруденція"},
                        new UDC{ Code = "340", Description = "Право в цілому. Пропедевтика. Методи та допоміжні правничі науки"},
                        new UDC{ Code = "341", Description = "Міжнародне право"},
                        new UDC{ Code = "342", Description = "Державне право. Конституційне право. Адміністративне право"},
                        new UDC{ Code = "343", Description = "Кримінальне право. Карні порушення"},
                        new UDC{ Code = "344", Description = "Особливі види кримінального права. Військове, військово-морське, військово-повітряне право"},
                        new UDC{ Code = "346", Description = "Господарське право. Правові основи державного регулювання економіки"},
                        new UDC{ Code = "347", Description = "Цивільне право. Судовий устрій"},
                        new UDC{ Code = "349.2", Description = "Трудове право"},
                        new UDC{ Code = "349.3", Description = "Право соціального забезпечення"},
                        new UDC{ Code = "349.4", Description = "Земельне право. Право планування населених пунктів"},
                        new UDC{ Code = "349.6", Description = "Правові проблеми охорони навколишнього середовища"},
                        new UDC{ Code = "349.7", Description = "Атомне право"},

                    new UDC{ Code = "35", Description = "Державне адміністративне управління. Військова справа"},
                        new UDC{ Code = "351", Description = "Напрями діяльності органів державного адміністративного управління"},
                        new UDC{ Code = "352", Description = "Нижній рівень органів управління. Органи місцевого управління. Муніципальна адміністрація. Місцеві органи"},
                        new UDC{ Code = "353", Description = "Середній рівень органів управління. Регіональне, провінційне управління. Регіональні органи"},
                        new UDC{ Code = "354", Description = "Вищий, найвищий рівень органів управління. Центральне, державне управління"},
                        new UDC{ Code = "355", Description = "Військова справа в цілому"},
                        new UDC{ Code = "356", Description = "Піхота"},
                        new UDC{ Code = "357", Description = "Кавалерія. Кінні війська. Моторизовані війська. Військово-транспортні частини"},
                        new UDC{ Code = "358", Description = "Артилерія. Бронетанкові війська. Інженерні війська. Військова авіація. Різні технічні служби та їх функції"},
                        new UDC{ Code = "359", Description = "Військово-морські сили. Військово-морський флот. Особовий склад, організація"},

                    new UDC{ Code = "36", Description = "Забезпечення духовних і матеріальних життєвих потреб"},
                        new UDC{ Code = "364", Description = "Соціальні проблеми, що породжують необхідність надання соціальної допомоги. Види соціальної допомоги"},
                        new UDC{ Code = "365", Description = "Потреба в житлі та її задоволення. Забезпечення житлом"},
                        new UDC{ Code = "366", Description = "Кос'юмеризм. Рух на захист інтересів та прав споживачів"},
                        new UDC{ Code = "368", Description = "Страхування. Суспільне забезпечення шляхом взаємного розподілу ризику"},
                        new UDC{ Code = "369", Description = "Соціальне страхування"},

                    new UDC{ Code = "37", Description = "Освіта. Виховання. Навчання. Дозвілля"},
                        new UDC{ Code = "37.0", Description = "Основні види та принципи освіти"},
                        new UDC{ Code = "371", Description = "Організація системи освіти та виховання. Шкільна організація"},
                        new UDC{ Code = "372", Description = "Зміст та форма діяльності в дошкільному вихованні та початковому навчанні. Предмети усіх рівнів навчання та типів шкіл (методика)"},
                        new UDC{ Code = "373", Description = "Види загальноосвітніх шкіл"},
                        new UDC{ Code = "374", Description = "Позашкільна освіта і підготовка. Подальша освіта (самоосвіта)"},
                        new UDC{ Code = "376", Description = "Освіта, навчання, підготовка спеціальних груп осіб. Спеціальні школи"},
                        new UDC{ Code = "377", Description = "Спеціалізоване навчання. Професійно-технічне навчання. Професійні коледжі. Політехнічна освіта"},
                        new UDC{ Code = "378", Description = "Вища освіта. Університети. Підготовка наукових кадрів"},
                        new UDC{ Code = "379.8", Description = "Дозвілля"},

                    new UDC{ Code = "39", Description = "Етнологія. Етнографія. Звичаї. Традиції. Спосіб життя. Фольклор"},
                        new UDC{ Code = "391", Description = "Народний одяг. Народні костюми. Національний одяг. Народні прикраси. Мода"},
                        new UDC{ Code = "392", Description = "Звичаї, традиції в особистому житті"},
                        new UDC{ Code = "393", Description = "Смерть. Поводження з померлими. Поховання. Обряди, пов'язані з похованнями"},
                        new UDC{ Code = "394", Description = "Громадське життя. Життя народу"},
                        new UDC{ Code = "395", Description = "Церемоніал. Етикет. Правила поведінки. Соціальні сходинки. Звання. Титули"},
                        new UDC{ Code = "396", Description = "Фемінізм. Жінка і суспільство. Становище жінки"},
                        new UDC{ Code = "397", Description = "Первісні народи. Окремі раси, племена з точки зору їх звичаїв"},
                        new UDC{ Code = "398", Description = "Фольклор у вузькому значенні"},


                new UDC{ Code = "5", Description = "Математика. Природничі науки"},
                    new UDC{ Code = "50", Description = "Загальні відомості про математичні та природничі науки"},
                        new UDC{ Code = "501", Description = "Загальні відомості про точні науки. Математичні науки в цілому, включаючи астрономію, механіку, математичну фізику"},
                        new UDC{ Code = "502", Description = "Природа. Дослідження природи та її збереження. Захист навколишнього середовища (довкілля) та живої природи"},
                        new UDC{ Code = "504", Description = "Наука про навколишнє середовище. Екологія"},

                    new UDC{ Code = "51", Description = "Математика"},
                        new UDC{ Code = "510", Description = "Фундаментальні та загальні питання математики"},
                        new UDC{ Code = "511", Description = "Теорія чисел"},
                        new UDC{ Code = "512", Description = "Алгебра"},
                        new UDC{ Code = "514", Description = "Геометрія"},
                        new UDC{ Code = "515.1", Description = "Nопологія"},
                        new UDC{ Code = "517", Description = "Аналіз"},
                        new UDC{ Code = "519.1", Description = "Комбінаторний аналіз. Теорія графів"},
                        new UDC{ Code = "519.2", Description = "Ймовірність. Математична статистика"},
                        new UDC{ Code = "519.6", Description = "Обчислювальна математика"},
                        new UDC{ Code = "519.7", Description = "Математична кібернетика"},
                        new UDC{ Code = "519.8", Description = "Дослідження операцій"},

                    new UDC{ Code = "52", Description = "Астрономія. Астрофізика. Космічні дослідження. Геодезія"},
                        new UDC{ Code = "520", Description = "Інструменти, прилади та методи астрономічних досліджень"},
                        new UDC{ Code = "521", Description = "Теоретична астрономія. Небесна механіка"},
                        new UDC{ Code = "523", Description = "Сонячна система"},
                        new UDC{ Code = "524", Description = "Зорі. Зоряні системи. Всесвіт"},
                        new UDC{ Code = "527", Description = "Морехідна та авіаційна астрономія. Навігація"},
                        new UDC{ Code = "528", Description = "Геодезія. Топографо-геодезичні роботи. Фотограмметрія. Дистанційне зондування."},

                    new UDC{ Code = "53", Description = "Фізика"},
                            new UDC{ Code = "530.1", Description = "Основні закони (принципи) фізики"},
                        new UDC{ Code = "531", Description = "Загальна механіка. Механіка твердих та жорстких тіл"},
                        new UDC{ Code = "532", Description = "Загальні питання механіки рідин. Механіка рідин (гідромеханіка)"},
                        new UDC{ Code = "533", Description = "Механіка газів. Аеромеханіка. Фізика плазми"},
                        new UDC{ Code = "534", Description = "Механічні коливання. Акустика"},
                        new UDC{ Code = "535", Description = "Оптика"},
                        new UDC{ Code = "536", Description = "Теплота. Термодинаміка"},
                        new UDC{ Code = "537", Description = "Електрика. Магнетизм. Електромагнетизм"},
                            new UDC{ Code = "538.9", Description = "Фізика конденсованої матерії (в рідинному і твердому стані)"},
                        new UDC{ Code = "539", Description = "Фізична теорія матерії"},

                    new UDC{ Code = "54", Description = "Хімія. Кристалографія. Мінералогія"},
                        new UDC{ Code = "542", Description = "Практична лабораторна хімія. Препаративна та експериментальна хімія"},
                        new UDC{ Code = "543", Description = "Аналітична хімія"},
                        new UDC{ Code = "544", Description = "Фізична хімія"},
                        new UDC{ Code = "546", Description = "Неорганічна хімія"},
                        new UDC{ Code = "547", Description = "Органічна хімія"},
                        new UDC{ Code = "548", Description = "Кристалографія"},
                        new UDC{ Code = "549", Description = "Мінералогія. Спеціальне мінераловедення"},

                    new UDC{ Code = "55", Description = "Геологія. Науки про землю"},
                        new UDC{ Code = "550", Description = "Допоміжні геологічні науки"},
                        new UDC{ Code = "551", Description = "Загальна геологія. Метеорологія. Кліматологія. Історична геологія. Стратиграфія. Палеогеографія"},
                        new UDC{ Code = "552", Description = "Петрологія. Петрографія"},
                        new UDC{ Code = "553", Description = "Економічна геологія. Родовища корисних копалин"},
                        new UDC{ Code = "556", Description = "Гідросфера. Вода в цілому. Гідрологія"},

                    new UDC{ Code = "56", Description = "Палеонтологія"},
                        new UDC{ Code = "561", Description = "Палеоботаніка. Систематика викопних рослин"},
                        new UDC{ Code = "562", Description = "Безхребетні в цілому"},
                        new UDC{ Code = "564", Description = "Молюски. М'якуни. Ракоподібні"},
                        new UDC{ Code = "565", Description = "Членисті"},
                        new UDC{ Code = "567", Description = "Риби"},
                        new UDC{ Code = "568", Description = "Зауропсиди. Ящероподібні"},
                        new UDC{ Code = "569", Description = "Ссавці"},

                    new UDC{ Code = "57", Description = "Біологічні науки в цілому"},
                        new UDC{ Code = "572", Description = "Антропологія"},
                        new UDC{ Code = "573", Description = "Загальна та теоретична біологія"},
                        new UDC{ Code = "574", Description = "Загальна екологія"},
                        new UDC{ Code = "575", Description = "Загальна генетика. Загальна цитогенетика"},
                        new UDC{ Code = "576", Description = "Клітинна та субклітинна біологія. Цитологія"},
                        new UDC{ Code = "577", Description = "Матеріальні основи життя. Біохімія. Молекулярна біологія. Біофізика"},
                        new UDC{ Code = "578", Description = "Вірусологія"},
                        new UDC{ Code = "579", Description = "Мікробіологія"},


                    new UDC{ Code = "58", Description = "Ботаніка"},
                        new UDC{ Code = "581", Description = "Загальна ботаніка"},
                        new UDC{ Code = "582", Description = "Систематика рослин"},

                    new UDC{ Code = "59", Description = "Зоологія"},
                        new UDC{ Code = "591", Description = "Загальна зоологія"},
                        new UDC{ Code = "592", Description = "Безхребетні"},
                        new UDC{ Code = "594", Description = "Молюски"},
                        new UDC{ Code = "595", Description = "Членисті"},
                        new UDC{ Code = "598", Description = "Ящероподібні"},
                        new UDC{ Code = "599", Description = "Ссавці"},


                new UDC{ Code = "6", Description = "Прикладні науки. Медицина. Техніка. Сільське господарство"},
                    new UDC{ Code = "60", Description = "Загальні питання прикладних наук"},

                    new UDC{ Code = "61", Description = "Медичні науки"},

                        new UDC{ Code = "613", Description = "Гігієна в цілому. Особисте здоров'я та гігієна"},
                        new UDC{ Code = "614", Description = "Суспільне здоров'я та гігієна. Попередження нещасних випадків"},
                        new UDC{ Code = "615", Description = "Фармакологія. Терапія. Токсикологія"},
                        new UDC{ Code = "616", Description = "Патологія. Клінічна медицина"},
                            new UDC{ Code = "616.1", Description = "Патологія серцево-судинної системи та крові"},
                            new UDC{ Code = "616.2", Description = "Патологія дихальної системи. Захворювання, пов'язані з органами дихання"},    
                            new UDC{ Code = "616.3", Description = "Патологія травної системи. Розлади травної системи"},    
                            new UDC{ Code = "616.4", Description = "Патологія лімфатичної системи, гемопатичних (кровотворних) органів, ендокринних органів"},    
                            new UDC{ Code = "616.5", Description = "Шкіра. Загальний шкірний покрив тіла. Клінічна дерматологія"},    
                            new UDC{ Code = "616.6", Description = "Патологія сечостатевої системи. Хвороби сечової та статевої систем"},    
                            new UDC{ Code = "616.7", Description = "Патологія органів руху, пересування. Скелетна та рухова системи"},    
                            new UDC{ Code = "616.8", Description = "Неврологія. Невропатологія. Нервова система"},    
                            new UDC{ Code = "616.9", Description = "Контактні захворювання. Інфекційні та заразні захворювання, гарячки"},    
                        new UDC{ Code = "617", Description = "Хірургія. Ортопедія. Офтальмологія"},
                        new UDC{ Code = "618", Description = "Гінекологія. Акушерство"},
                        new UDC{ Code = "619", Description = "Ветеринарна медицина"},

                    new UDC{ Code = "62", Description = "Машинобудування. Техніка в цілому"},
                        new UDC{ Code = "620", Description = "Випробування матеріалів. Матеріали промислового значення. Електростанції. Енергозбереження"},
                        new UDC{ Code = "621", Description = "Загальне машинобудування. Ядерна техніка. Електротехніка. Машинобудування в цілому"},
                        new UDC{ Code = "622", Description = "Гірнича справа"},
                        new UDC{ Code = "624", Description = "Будівництво інженерних споруд та будівельні конструкції в цілому"},
                        new UDC{ Code = "625", Description = "Шляхове будівництво. Будівництво залізниць. Будівництво автомобільних доріг"},
                        new UDC{ Code = "628", Description = "Санітарна техніка. Водопостачання. Водопровід і каналізація. Освітлювальна техніка"},
                        new UDC{ Code = "629", Description = "Транспорт"},

                    new UDC{ Code = "63", Description = "Сільське господарство. Лісове господарство. Мисливство. Рибне господарство"},
                        new UDC{ Code = "630", Description = "Лісове господарство. Лісівництво"},
                        new UDC{ Code = "631", Description = "Загальні питання сільського господарства"},
                            new UDC{ Code = "631.1", Description = "Організація та управління сільським господарством"},
                            new UDC{ Code = "631.2", Description = "Сільськогосподарські будівлі, споруди (експлуатація обладнання). Будівлі для домашньої худоби, продукції, машинного устаткування"},
                            new UDC{ Code = "631.3", Description = "Сільськогосподарські машини, знаряддя та інструменти"},
                            new UDC{ Code = "631.4", Description = "Грунтознавство. Грунтові дослідження"},
                            new UDC{ Code = "631.5", Description = "Сільськогосподарські роботи. Агротехніка"},
                            new UDC{ Code = "631.6", Description = "Сільськогосподарська меліорація"},
                            new UDC{ Code = "631.8", Description = "Добрива. Збагачення органічних і неорганічних добрив. Стимулювання росту рослин. Ростові речовини. Рослинні стимулятори"},   

                        new UDC{ Code = "632", Description = "Хвороби рослин. Шкідники рослин. Захист рослин"},
                            new UDC{ Code = "632.1", Description = "Непаразитичні хвороби. Рослинні хвороби комплексного походження"},
                            new UDC{ Code = "632.2", Description = "Симптоматологія рослин"},
                            new UDC{ Code = "632.3", Description = "Бактеріальні та вірусні хвороби рослин"},
                            new UDC{ Code = "632.4", Description = "Грибкові хвороби рослин"},
                            new UDC{ Code = "632.5", Description = "Шкідливі рослини (тобто шкідливі для інших рослин)"},
                            new UDC{ Code = "632.6", Description = "Тварини — шкідники рослин (крім комах)"},
                            new UDC{ Code = "632.7", Description = "Комахи — шкідники рослин"},
                            new UDC{ Code = "632.8", Description = "Інші шкідники та хвороби рослин"},
                            new UDC{ Code = "632.9", Description = "Боротьба з хворобами рослин та шкідниками рослин"},
                        new UDC{ Code = "633", Description = "Рільництво. Польові сільськогосподарські культури та їх виробництво"},
                            new UDC{ Code = "633.1", Description = "Хлібні злаки. Зернові культури"},
                            new UDC{ Code = "633.2", Description = "Кормові трави. Лугові та пасовищні трави"},
                            new UDC{ Code = "633.3", Description = "Кормові рослини (крім трави)"},
                            new UDC{ Code = "633.4", Description = "Харчові коренеплоди та бульби. Коренеплоди"},
                            new UDC{ Code = "633.5", Description = "Прядильні та волокнисті культури"},
                            new UDC{ Code = "633.6", Description = "Цукрові та крохмалеві рослини"},
                            new UDC{ Code = "633.7", Description = "Збуджуючі і наркотичні рослини. Рослини, що використовуються у виробництві напоїв"},
                            new UDC{ Code = "633.8", Description = "Ароматичні (ефіроолійні) рослини. Рослини-приправи. Олійні рослини. Красильні рослини. Дубильні рослини. Лікарські рослини"},
                            new UDC{ Code = "633.9", Description = "Інші рослини промислового використання"},
                        new UDC{ Code = "634", Description = "Садівництво в цілому. Плодівництво"},
                            new UDC{ Code = "634.1", Description = "Плодівництво в цілому"},
                            new UDC{ Code = "634.2", Description = "Кісточкові плоди в цілому"},
                            new UDC{ Code = "634.3", Description = "Рутові (включаючи цитрусові). Шовковичні (тутові). Загальні питання"},
                            new UDC{ Code = "634.4", Description = "Інші плодові"},
                            new UDC{ Code = "634.5", Description = "Горіхоплодові"},
                            new UDC{ Code = "634.6", Description = "Різноманітні тропічні та субтропічні плодові"},
                            new UDC{ Code = "634.7", Description = "Невеликі плоди кущів та трав'яних рослин. Ягідні культури"},
                            new UDC{ Code = "634.8", Description = "Виноградарство. Культурні сорти винограду. Виноградники"},
                        new UDC{ Code = "635", Description = "Овочівництво і декоративне садівництво"},
                            new UDC{ Code = "635.1", Description = "Столові (харчові) коренеплоди"},
                            new UDC{ Code = "635.2", Description = "Харчові бульбоплоди та цибулинні"},
                            new UDC{ Code = "635.3", Description = "Рослини з їстівними стеблами, листям або квітками"},
                            new UDC{ Code = "635.4", Description = "Інші зелені овочеві культури. Листові овочеві"},
                            new UDC{ Code = "635.5", Description = "Салатні рослини. Салатні овочі"},
                            new UDC{ Code = "635.6", Description = "Рослини з їстівними плодами та насінням. Бобові культури"},
                            new UDC{ Code = "635.7", Description = "Ароматичні, запашні трави. Пряні рослини"},
                            new UDC{ Code = "635.8", Description = "Гриби"},
                            new UDC{ Code = "635.9", Description = "Декоративні рослини. Декоративне садівництво"},
                        new UDC{ Code = "636", Description = "Загальні питання тваринництва. Розведення тварин і птахів. Скотарство. Домашні тварини та їх розведення"},
                            new UDC{ Code = "636.1", Description = "Однокопитні (непарнокопитні) тварини. Домашні коні. Коні східні, азіатські коні"},
                            new UDC{ Code = "636.2", Description = "Велика рогата худоба"},
                            new UDC{ Code = "636.3", Description = "Малі жуйні тварини. Мала рогата худоба. Вівці. Кози"},
                            new UDC{ Code = "636.4", Description = "Свині"},
                            new UDC{ Code = "636.5", Description = "Домашні птахи"},
                            new UDC{ Code = "636.6", Description = "Птахи (крім домашніх та бійцівських птахів), які розводять або утримують люди"},
                            new UDC{ Code = "636.7", Description = "Собаки"},
                            new UDC{ Code = "636.8", Description = "Кішки"},
                            new UDC{ Code = "636.9", Description = "Інші тварини, яких утримують люди"},
                        new UDC{ Code = "637", Description = "Продукти тваринництва"},
                            new UDC{ Code = "637.1", Description = "Молочна промисловість у цілому"},
                            new UDC{ Code = "637.2", Description = "Масло та маслоробство"},
                            new UDC{ Code = "637.3", Description = "Сир та сироварство"},
                            new UDC{ Code = "637.4", Description = "Яйця. Продукти переробки яєць"},
                            new UDC{ Code = "637.5", Description = "М'ясо. Свіжі м'ясні харчові продукти"},
                            new UDC{ Code = "637.6", Description = "Інша тваринна продукція (крім харчової)"},
                        new UDC{ Code = "638", Description = "Догляд, утримання і розведення комах та інших членистоногих"},
                            new UDC{ Code = "638.1", Description = "Бджільництво. Утримання бджіл"},
                            new UDC{ Code = "638.2", Description = "Розведення шовковичного шовкопряда. Шовківництво"},
                            new UDC{ Code = "638.3", Description = "Комахи кошеніль"},
                            new UDC{ Code = "638.4", Description = "Виведення, розведення інших комах"},
                            new UDC{ Code = "638.5", Description = "Розведення павукоподібних комах"},
                            new UDC{ Code = "638.8", Description = "Утримання комах з декоративною метою"},
                        new UDC{ Code = "639", Description = "Полювання, мисливство. Рибне господарство. Рибальство"},
                            new UDC{ Code = "639.1", Description = "Полювання"},
                            new UDC{ Code = "639.2", Description = "Риболовля. Рибальство і його продукти"},
                            new UDC{ Code = "639.3", Description = "Риборозведення. Рибництво"},
                            new UDC{ Code = "639.4", Description = "Розведення водяних молюсків"},
                            new UDC{ Code = "639.5", Description = "Розведення ракоподібних, морських їжаків, п'явок тощо"},
                            new UDC{ Code = "639.6", Description = "Інші морепродукти"},

                        new UDC{ Code = "64", Description = "Домоведення. Комунальне господарство. Служба побуту"},
                            new UDC{ Code = "640", Description = "Типи комунально-побутових підприємств та домашнє господарство"},
                            new UDC{ Code = "641", Description = "Продукти харчування. Приготування їжі. Страви"},
                            new UDC{ Code = "642", Description = "Їжа та вживання їжі. Столовий посуд"},
                            new UDC{ Code = "643", Description = "Житло. Помешкання"},
                            new UDC{ Code = "644", Description = "Санітарно-технічне обладнання помешкань"},
                            new UDC{ Code = "645", Description = "Предмети обстановки жила"},
                            new UDC{ Code = "646", Description = "Одяг. Особиста гігієна"},
                            new UDC{ Code = "647", Description = "Обслуговуючий персонал у домашньому та комунально-побутовому господарстві"},
                            new UDC{ Code = "648", Description = "Прання. Пральні. Чистка. Прибирання приміщень"},
                            new UDC{ Code = "649", Description = "Догляд за дітьми, хворими, інвалідами та прийом гостей"},
                        new UDC{ Code = "65", Description = "Керування підприємствами. Менеджмент. Організація виробництва, торгівлі, транспорту, зв'язку, поліграфії"},
                            new UDC{ Code = "651", Description = "Конторська (канцелярська) справа. Офіс-менеджмент. Діловодство. Оргтехніка"},
                            new UDC{ Code = "654", Description = "Електрозв'язок (організація та експлуатація)"},
                            new UDC{ Code = "655", Description = "Поліграфічна промисловість. Поліграфічні підприємства. Видавництва. Книжкова торгівля"},
                            new UDC{ Code = "656", Description = "Транспортні та поштові служби. Організація та керування перевезеннями"},
                            new UDC{ Code = "657", Description = "Бухгалтерія. Бухгалтерський облік. Рахівництво"},
                            new UDC{ Code = "658", Description = "Організація виробництва, менеджмент. Економіка підприємств. Організація та техніка торгівлі"},
                            new UDC{ Code = "659", Description = "Реклама. Система інформації. Служба зовнішньої інформації та реклами (паблик рілейшнз)"},
                        new UDC{ Code = "66", Description = "Хімічна технологія. Хімічна промисловість і споріднені галузі"},
                            new UDC{ Code = "661", Description = "Продукти хімічної промисловості"},
                            new UDC{ Code = "662", Description = "Вибухові речовини. Паливо"},
                            new UDC{ Code = "663", Description = "Промислова мікробіологія. Промислова мікологія. Бродильне виробництво, промисловість ферментів. Виробництво напоїв. Виробництво спиртних напоїв"},
                            new UDC{ Code = "664", Description = "Харчова промисловість у цілому. Виробництво і консервування харчових продуктів"},
                            new UDC{ Code = "665", Description = "Олії. Жири. Віск. Клеї. Камеді. Смоли"},
                            new UDC{ Code = "666", Description = "Скляна і керамічна промисловість. Промисловість в'яжучих. Цемент і бетон"},
                            new UDC{ Code = "667", Description = "Лакофарбова промисловість"},
                            new UDC{ Code = "669", Description = "Металургія"},
                        new UDC{ Code = "67", Description = "Різні галузі промисловості та ремесла"},
                            new UDC{ Code = "671", Description = "Вироби з дорогоцінних металів та коштовного каменю"},
                            new UDC{ Code = "672", Description = "Вироби з заліза та сталі в цілому"},
                            new UDC{ Code = "673", Description = "Вироби з кольорових металів (за винятком дорогоцінних металів)"},
                            new UDC{ Code = "674", Description = "Деревообробна промисловість"},
                            new UDC{ Code = "675", Description = "Шкіряна промисловість (включаючи виробництво хутра і штучної шкіри)"},
                            new UDC{ Code = "676", Description = "Целюлозно-паперова промисловість"},
                            new UDC{ Code = "677", Description = "Текстильна промисловість"},
                            new UDC{ Code = "678", Description = "Промисловість високомолекулярних речовин. Виробництво гуми. Виробництво пластмас"},
                            new UDC{ Code = "679", Description = "Галузі промисловості з переробки різних матеріалів"},
                        new UDC{ Code = "68", Description = "Галузі промисловості та ремесла, що виробляють готову продукцію"},
                            new UDC{ Code = "681", Description = "Точна механіка та автоматика"},
                            new UDC{ Code = "682", Description = "Ковальська справа. Підковування тварин. Виготовлення кованих виробів"},
                            new UDC{ Code = "683", Description = "Залізні вироби. Слюсарна справа. Лампи з горючими речовинами. Печі"},
                            new UDC{ Code = "684", Description = "Меблева промисловість"},
                            new UDC{ Code = "685", Description = "Виробництво шорно-сідельних та інших виробів із шкіри. Взуттєве виробництво. Виробництво туристичного та спортивного інвентаря"},
                            new UDC{ Code = "686", Description = "Брошурувально-палітурне виробництво. Золотіння. Срібнення. Виробництво дзеркал. Канцелярські приладдя"},
                            new UDC{ Code = "687", Description = "Швейна промисловість. Виробництво косметичних виробів"},
                            new UDC{ Code = "688", Description = "Галантерейні та декоративні вироби. Іграшки"},
                            new UDC{ Code = "689", Description = "Технічні та інші аматорські ручні роботи"},
                        new UDC{ Code = "69", Description = "Будівельна промисловість. Будівельні матеріали. Будівельно-монтажні роботи"},
                            new UDC{ Code = "691", Description = "Будівельні матеріали та компоненти"},
                            new UDC{ Code = "692", Description = "Конструктивна частина та елементи будов"},
                            new UDC{ Code = "693", Description = "Кам'яна або цегляна кладка та пов'язані з нею будівельні роботи"},
                            new UDC{ Code = "694", Description = "Дерев'яні конструкції. Деревообробне виробництво. Столярні роботи"},
                            new UDC{ Code = "696", Description = "Санітарно-технічне, газове, парове, електричне обладнання будівель та його монтаж"},
                            new UDC{ Code = "697", Description = "Обігрівання, вентиляція та кондиціювання повітря в будовах"},
                            new UDC{ Code = "698", Description = "Оздоблювальні та декоративні роботи"},
                            new UDC{ Code = "699.8", Description = "Захисні засоби всередині та зовні будинків. Протиаварійні заходи"},


                new UDC{ Code = "7", Description = "Мистецтво. Архітектура. Ігри. Спорт"},
                    new UDC{ Code = "71", Description = "Планування у межах адміністративно-територіальних одиниць. Ландшафти, парки, сади"},
                        new UDC{ Code = "711", Description = "Принципи та практика планування. Планування в межах адміністративно-територіальних одиниць"},
                        new UDC{ Code = "712", Description = "Ландшафтна архітектура (природна та спроектована). Парки. Сади, сквери"},
                        new UDC{ Code = "718", Description = "Кладовища. Крематорії. Інші місця поховання померлих (планування, обладнання, догляд тощо)"},
                        new UDC{ Code = "719", Description = "Охорона сільських і міських історичних і культурних пам'яток"},
                    new UDC{ Code = "72", Description = "Архітектура"},
                        new UDC{ Code = "721", Description = "Будівлі в цілому"},
                        new UDC{ Code = "725", Description = "Державні, громадські, торгові, промислові будівлі. Цивільна архітектура в цілому"},
                        new UDC{ Code = "726", Description = "Культові споруди та будівлі. Священні та погребальні будівлі"},
                        new UDC{ Code = "727", Description = "Будівлі освітніх, наукових та культурно-освітніх заходів"},
                        new UDC{ Code = "728", Description = "Житлова архітектура. Житлове будівництво. Житло"},
                    new UDC{ Code = "73", Description = "Пластичні мистецтва"},
                        new UDC{ Code = "730", Description = "Скульптура в цілому"},
                        new UDC{ Code = "736", Description = "Гліптика. Сфрагістика"},
                        new UDC{ Code = "737", Description = "Нумізматика"},
                        new UDC{ Code = "739", Description = "Художня обробка металу"},
                    new UDC{ Code = "74", Description = "Малювання та креслення. Дизайн. Декоративно-прикладне мистецтво. Художні промисли"},
                        new UDC{ Code = "741", Description = "Малювання та креслення в цілому"},
                        new UDC{ Code = "742", Description = "Перспектива в малюнках та кресленнях"},
                        new UDC{ Code = "743", Description = "Анатомічне малювання"},
                        new UDC{ Code = "744", Description = "Геометричне креслення. Технічне креслення"},
                        new UDC{ Code = "746", Description = "Рукоділля. Художнє вишивання"},
                        new UDC{ Code = "747", Description = "Оформлення інтер'єру"},
                        new UDC{ Code = "748", Description = "Мистецтво скляних виробів. Художні вироби зі скла та кришталю"},
                        new UDC{ Code = "749", Description = "Художні меблі, прилади опалення та освітлення"},
                    new UDC{ Code = "75", Description = "Живопис"},
                    new UDC{ Code = "76", Description = "Графічні мистецтва. Графіка"},
                        new UDC{ Code = "761", Description = "Гравюра високого друку"},
                        new UDC{ Code = "762", Description = "Гравюра глибокого друку"},
                        new UDC{ Code = "763", Description = "Гравюра плоского друку"},
                        new UDC{ Code = "766", Description = "Прикладна графіка. Рекламна графіка"},
                        new UDC{ Code = "769", Description = "Види гравюр"},
                    new UDC{ Code = "77", Description = "Фотографія, кінематографія та подібні процеси"},
                        new UDC{ Code = "771", Description = "Фотографічне обладнання, апарати та матеріали"},
                        new UDC{ Code = "772", Description = "Фотографічні системи, або процеси з використанням неорганічних речовин або фізичних явищ"},
                        new UDC{ Code = "773", Description = "Фотографічні системи, або процеси з використанням органічних сполук"},
                        new UDC{ Code = "774", Description = "Фотомеханічні процеси в цілому"},
                        new UDC{ Code = "776", Description = "Фотолітографія. Фотографічні процеси виготовлення друкарських форм для плоского друку"},
                        new UDC{ Code = "777", Description = "Форми глибокого друку. Фотогравюра. Форми високого друку (штрихові та растрові)"},
                        new UDC{ Code = "778", Description = "Спеціальні галузі застосування та фототехніка"},
                    new UDC{ Code = "78", Description = "Музика"},
                        new UDC{ Code = "781", Description = "Теорія музики. Загальні питання"},
                        new UDC{ Code = "782", Description = "Театральна музика. Опера"},
                        new UDC{ Code = "783", Description = "Церковна музика. Духовна музика. Релігійна музика"},
                        new UDC{ Code = "784", Description = "Вокальна музика. Співи"},
                        new UDC{ Code = "785", Description = "Інструментальна музика. Симфонічна музика. Музика для оркестрів. Музика для ансамблів"},
                        new UDC{ Code = "786", Description = "Музика для клавішних інструментів"},
                        new UDC{ Code = "787", Description = "Музика для смичкових та струнних інструментів"},
                        new UDC{ Code = "788", Description = "Музика для духових інструментів"},
                        new UDC{ Code = "789", Description = "Музика для ударних інструментів. Музика для механічних музичних інструментів"},
                    new UDC{ Code = "79", Description = "Видовищні мистецтва. Розваги. Ігри. Спорт"},
                        new UDC{ Code = "791", Description = "Масові розваги. Вистави. Виставки"},
                        new UDC{ Code = "792", Description = "Театр. Сценічне мистецтво. Драматичні вистави"},
                        new UDC{ Code = "793", Description = "Відпочинок та розваги громадськості. Мистецтво руху. Танці"},
                        new UDC{ Code = "794", Description = "Настільні ігри (на кмітливість, спритність та удачу)"},
                        new UDC{ Code = "796", Description = "Спорт. Ігри. Фізичні вправи"},
                        new UDC{ Code = "797", Description = "Водний спорт. Авіаційний спорт"},
                        new UDC{ Code = "798", Description = "Кінний спорт та верхова їзда. Спортивні змагання на конях та інших тваринах"},
                        new UDC{ Code = "799", Description = "Спортивне рибальство. Спортивне мисливство. Спортивна стрільба по цілях"},

                new UDC{ Code = "8", Description = "Мова. Мовознавство. Художня література. Літературознавство"},
                    new UDC{ Code = "80", Description = "Загальні питання лінгвістики та літератури. Філологія"},
                        new UDC{ Code = "801", Description = "Просодія. Віршування. Допоміжні науки та джерела філології"},
                        new UDC{ Code = "808", Description = " Риторика. Ефективне застосування мови"},
                    new UDC{ Code = "81", Description = "Лінгвістика. Мовознавство. Мови"},
                    new UDC{ Code = "82", Description = "Художня література. Літературознавство"},

                new UDC{ Code = "9", Description = "Географія. Біографії. Історія"},
                    new UDC{ Code = "90", Description = ""}, //!
                        new UDC{ Code = "902", Description = "Археологія"},
                        new UDC{ Code = "903", Description = "Передісторія. Доісторичні залишки. Знаряддя праці. Старожитності"},
                        new UDC{ Code = "904", Description = "Археологічні пам'ятки історичних часів"},
                        new UDC{ Code = "908", Description = "Краєзнавство"},
                    new UDC{ Code = "91", Description = "Географія. Географічні дослідження Землі та окремих країн."},
                    new UDC{ Code = "92", Description = ""}, //!
                        new UDC{ Code = "929", Description = "Біографічні та подібні дослідження"},
                    new UDC{ Code = "93", Description = "Історія"},
                        new UDC{ Code = "930", Description = "Історична наука"},
                    new UDC{ Code = "94", Description = "Загальна історія"},
            };
            UDCs.ForEach(u => context.UDCs.AddOrUpdate(t => t.Code, u));
            context.SaveChanges();

            List<Book> books = new List<Book>
            {
                new Book
                {
                    Name = "Сборник задач по курсу математического анализа",
                    Publishing = "Профессия, 22-е издание",
                    EditionYear = 2001,
                    Pages = 432,
                    UDCID = context.UDCs.First(u=>u.Code=="517").ID
                    /*UDC = "TBD",
                    AuthorsList = new List<Author> {context.Authors.FirstOrDefault(a => a.LastName == "Берман")}*/
                },
                new Book
                {
                    Name = "Сборник задач и упражнений по математическому анализу",
                    Publishing = "ЧеРоб, 13 издание",   
                    EditionYear = 1997,
                    Pages = 624,
                    UDCID = context.UDCs.First(u=>u.Code=="517").ID
                    /*UDC = "TBD",
                    AuthorsList = new List<Author> {context.Authors.FirstOrDefault(a => a.LastName == "Демидович")},*/
                }
            };
            books.ForEach(b => context.Books.AddOrUpdate(t => t.Name, b));
            context.SaveChanges();


            List<BookCopy> bookCopies = new List<BookCopy>
            {
                new BookCopy{BookID = books.Single(b=>b.Name=="Сборник задач по курсу математического анализа").ID, StatusID = statuses.Single(s=>s.Name=="available").ID},
                new BookCopy{BookID = books.Single(b=>b.Name=="Сборник задач по курсу математического анализа").ID, StatusID = statuses.Single(s=>s.Name=="given away").ID},
                new BookCopy{BookID = books.Single(b=>b.Name=="Сборник задач по курсу математического анализа").ID, StatusID = statuses.Single(s=>s.Name=="reading room").ID},
                new BookCopy{BookID = books.Single(b=>b.Name=="Сборник задач и упражнений по математическому анализу").ID, StatusID = statuses.Single(s=>s.Name=="available").ID}
            };
            foreach (var bookCopy in bookCopies)
            {
                var bookCopyInDB =
                    context.BookCopies.SingleOrDefault(
                        b => b.BookID == bookCopy.BookID && b.StatusID == bookCopy.StatusID);
                if (bookCopyInDB == null) context.BookCopies.Add(bookCopy);
            }
            context.SaveChanges();


            List<RequestType> requestTypes = new List<RequestType>
            {
                new RequestType{ Name = "read"},
                new RequestType{ Name = "take"}
            };
            requestTypes.ForEach(r => context.RequestTypes.AddOrUpdate(t => t.Name, r));
            context.SaveChanges();

            List<ReadingCard> readingCards = new List<ReadingCard>
            {
                new ReadingCard
                {
                    Name = "Borys",
                    LastName = "Symonenko",
                    SecondName = "Oleksandrovych",
                    BirthDate = DateTime.Now,
                    Passport = "3434434",
                    PhoneNumber = "+34344343",
                    PlaceOfWork = "university",
                    WorkPosition = "student",
                    RegistrationDate = DateTime.Now
                },
                new ReadingCard
                {
                    Name = "Oleksandr",
                    LastName = "Grebeniuk",
                    SecondName = "Unknown",
                    BirthDate = DateTime.Now,
                    Passport = "3434465",
                    PhoneNumber = "+343423343",
                    PlaceOfWork = "university",
                    WorkPosition = "student",
                    RegistrationDate = DateTime.Now
                }
            };
            readingCards.ForEach(r=>context.ReadingCards.AddOrUpdate(t=>t.Passport, r));
            context.SaveChanges();
        }
    }
}
