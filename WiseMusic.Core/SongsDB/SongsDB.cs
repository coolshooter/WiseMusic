﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseMusic.Core
{
	/// <summary>
	/// Источники: 
	/// http://5lad.ru/akkordy/
	/// </summary>
	public class SongsDB
	{
		public List<Song> Songs { get; set; }

		public SongsDB()
		{
			Songs = new List<Song>();

			AddBeyonce();
			AddBackstreetBoys();
			AddTinaTurner();
			AddDelerium();
			AddWestlife();
			AddBonnieTyler();
			AddHoobastank();

			AddZveri();
			AddMumiyTroll();
			AddKino();
			AddFactor2();
			AddAniLorak();
			AddElenaTerleeva();
			AddSavicheva();

			Songs = Songs.OrderBy(s => s.DisplayName).ToList();
		}

		void AddBeyonce()
		{
			Add("Beyonce - Halo", true,
@"
G Am Em C
G Am Em C
G Am
Em
C
G
Am
Em
C
G
");
		}

		void AddBackstreetBoys()
		{
			Add("Backstreet Boys - Incomplete", true,
@"
F#m C#m
E B
F#m C#m E
B            
F#m C#m      
E B
F#m C#m E B A
C#m E
B A
C#m E
B
C#m E
B             
A C#m B  
F#m C#m E B 
A
C#m B
B A
C#m B
");

			AddRusKeysLines("Backstreet boys - Everybody (составлено вручную)",
@"
си-бемоль минор
соль-бемоль мажор
фа мажор
си-бемоль минор
");
		}

		void AddTinaTurner()
		{
			Add("Tina Turner - Simply the best", true,
@"F Dm Bb F Dm Bb C, F, 
Dm, C7, F, Dm, C7, F,
Dm Bb C, Bb Dm Bb C D G
Sax solo: G,Em,D7
G Em D7 G Em D7 G (ring)");
		}

		void AddDelerium()
		{
			Add("Delerium - Silence", true,
@"
Am
G F Am
G F Am
Em
G
F Am
G F Am
G F Am
Am
G
F Am
Am G C G
Dm G Am
Dm G Am
G F Am
G F Am
Am
G
F Am
Dm G Am
Dm G Am
Dm G Am
Dm G Am
");
		}

		void AddWestlife()
		{
			Add("Westlife - What about now", true,
@"Dm Am Dm Am G
Dm Am G 
Bb F Dm Bb Gm F Dm Bb Gm F Bb Dm
");

		}

		void AddBonnieTyler()
		{
			Add("Bonnie Tyler - Total eclipse of the heart", true,
@"
Bm                                     A 
TURN AROUND Every now and then I ....
Bm chord                                      A 
TURN AROUND Every now and then I get a ....
D                                       C 
TURN AROUND Every now and then ...
D                                       C 
TURN AROUND Every now and then I ...
F chord                        Bb 
TURN AROUND, BRIGHT EYES ...
F chord                        Bb 
TURN AROUND, BRIGHT EYES Every ....

Bm chord                                      A 
TURN AROUND Every now and then ...
Bm chord                                      A 
TURN AROUND Every now and then I get ...
D                                       C 
TURN AROUND Every now and then I ...
D                                       C 
TURN AROUND Every now and then I ...
F chord                         Bb 
TURN AROUND, BRIGHT EYES Every ...
F chord                         Bb                             A 
TURN AROUND, BRIGHT EYES Every ...

            F#m                  D         E                   A 
      And I need you now tonight ...
                 F#m             D               E              A 
      and if you only hold me tight we'll ...
                F#m                  D                   E 
      And we'll only be making it right ...
      D                               E 
      Together we can take it to the ...
           F#m                           B 
      Your love is like a shadow ...
        A                              E /G# 
      I don't know what to do and ...
            F#m                          B 
      We're living in a powder keg and ...
                        D            B              C#m      D 
      I really need you tonight, ...,
         E 
      forever's gonna ...

   A                       F#m                   C#m 
D    A /C# 
   Once upon a time I was falling in ...
apart.
           Bm chord                  E 
   There's nothing I can do, a total ...
    A                 F#m                 D           E 
   A                           F#m                    C#m 
   Once upon a time there was light in my ...
in
           D     A /C# 
       the dark.
   Bm chord                   E                     A 
   Nothing I can say, a ...
");
						
		}

		//		тут многое шло через дробь, и непонятно, что она означала
		void AddHoobastank()
		{
Add("Hoobastank - The reason", true,
@"E5 C#m E5 C#m A B5 E5
C#m G# A5 B F# D E F# D E F# G# E D E
C#m7 A A9 B7 E");
		}


		void AddZveri()
		{
			Add("Звери - районы-кварталы", false,
@"
Вступление: Am Dm E Am F Dm E Am

 Am         Dm
Больше нечего ловить -
  E           Am
Все что надо, я поймал.
           Dm
Надо сразу уходить,
  E             Am
Чтоб никто не привыкал.

          Dm
Ярко-желтые очки,
  E           Am
Два сердечка на брелке,
 F       Dm
Развеселые зрачки,
  E
Твое имя на руке.

  Припев:
        Am        Dm      E      Am
     Районы, кварталы, жилые массивы.
     F     Dm     E     Am
     Я ухожу, ухожу красиво.

     Районы, кварталы, жилые массивы.
     Я ухожу, ухожу красиво.

У тебя все будет класс,
Будут ближе облака.
Я хочу, как в первый раз,
И поэтому - пока!

Ярко-желтые очки,
Два сердечка на брелке,
Развеселые зрачки,
Я шагаю налегке.

  Припев

Вот и все, никто не ждет,
И никто не в дураках.
Кто-то любит, кто-то врет
И летает в облаках.

Ярко-желтые очки,
Два сердечка на брелке,
Развеселые зрачки,
Я шагаю налегке.

  Припев");

			Add("Звери - все, что тебя касается (проверено начало)", false,
@"Вступление: E Am E Am

E
Такие маленькие телефоны,
Am
Такие маленькие перемены,
E
Законы Ома еще не знакомы,
F                   Dm
В таких ботинках моря по колено.

E
Не надо думать, что все обойдется,
Am
Не напрягайся, не думай об этом,
E
Все будет круто, все перевернется,
F E
А-а...

  Припев:
       Am             Dm
     Все, что тебя касается,
       E              Am
     Все, что меня касается,
       F             Dm
     Все только начинается,
      E    Am    E
     Начинается. А!

       Am             Dm
     Все, что тебя касается,
       E              Am
     Все, что меня касается,
       F             Dm
     Все только начинается,
      E    Am
     Начинается.


Какие мысли, какие сюжеты,
Еще чуть-чуть и посыпятся звезды,
В карманах медленно тают конфеты,
Мы понимаем, что это серьезно.

Не надо думать, что все обойдется,
Не напрягайся, не думай об этом,
Все будет круто, все перевернется,
А-а-а...

  Припев

Ты задеваешь меня за живое,
Давай сейчас, а потом еще ночью,
Ты будешь рядом, ты будешь со мною,
И между нами любовь - это точно.

Не надо думать, что все обойдется,
Не напрягайся, не думай об этом,
Все будет круто, все перевернется,
А-а-а...

  Припев");

			Add("Звери - Напитки покрепче", false,
@"  Вступление: Cm F A# Gm
Gm                Cm
И нигде и ни во сколько
 F                 Gm
Повстречались и забыли.
                     Cm
Брызги, капельки, осколки
 F             Gm
Никого не зацепили.

Брызги, капельки на ветер,
И тебя никто не тронет.
Дядя Степа на конфете
Помещается в ладони.

       Припев:
        Cm       F
     Напитки покрепче,
         A#     Gm
     Слова покороче -
          Cm         F
     Так проще, так легче
         A#     Gm
     Стираются ночи.

     Звонки без ответа,
     Слова и улыбки.
     Вчерашнее лето,
     Смешная ошибка.

А давай, как будто праздник:
В небо шарики, салюты.
Синий, белый, желтый, красный.
Брызги, капельки, минуты.

Падаю на ровном месте,
Зацепиться бы за воздух.
Там, где нолик, ставил крестик.
Там, где рано, ставил поздно.

  Припев

Брызги, капельки, минуты.
Становился чемпионом.
Выбирал себе маршруты,
Выбирал себе перроны.

И нигде и ни во сколько,
Что бы не было вопросов.
Брызги, капельки, осколки,
Холостые папиросы.

  Припев");
		}

		void AddMumiyTroll()
		{
			Add("Муммий тролль - инопланетный гость", false,
@"Am F G Am - 2 раза
Am            F         G            Am
В ночном небе нет комет, вся планета в мире снов.
Am             F              G              Am
Вдалеке увидел тусклый свет – это знак из других миров.
И тревожит меня мысль: не один среди звезд я живу.
Визит этот будет вечен – встреча братьев по уму.
Припев:
Am           F     G          Am
Инопланетный гость летит издалека,
Инопланетный гость не знаю я пока,
Что ты мне принесешь? И сколько бы отдал?
Am               F   G                   F  E
Чтоб ты бы поскорее, к нам в гости прилетал, инопланетный!
Контакт быть может, может быть бессмертны станем мы.
И сможем запросто летать в далекие миры,
Черный космос бороздя, кто заглянет в нашу дверь?
Ты зашел бы сам в мир иной, друг дорогой?
Припев
");
		}

		void AddKino()
		{
			Add("Кино - Звезда по имени Солнце", false,
@"Вступление: Dm Am Dm Am Dm Am Dm Am
        Am
Белый снег, серый лёд
        C
На растрескавшейся земле.
  Dm
Одеялом лоскутным на ней
 G
Город в дорожной петле.
       Am
А над городом плывут облака,
      C
Закрывая небесный свет.
       Dm
А над городом - жёлтый дым.
 G
Городу две тысячи лет,
  Dm
Прожитых под светом звезды
          Am
По имени Солнце.

И две тысячи лет война,
Война без особых причин.
Война - дело молодых.
Лекарство против морщин.
Красная-красная кровь -
Через час уже просто земля,
Через два на ней цветы и трава,
Через три она снова жива.
И согрета лучами звезды
По имени Солнце.

И мы знаем, что так было всегда:
Что судьбою больше любим,
Кто живёт по законам другим
И кому умирать молодым.
Он не помнит слово да и слово нет,
Он не помнит ни чинов, ни имён.
И способен дотянуться до звёзд,
Не считая, что это сон.
И упасть, опалённым звездой
По имени Солнце.");

			AddRusKeysLines("Кино - Кукушка (составлено вручную)",
@"
ля минор
соль мажор
фа мажор
ля минор
");

			Add("Кино - Кончится лето", false,
@" Em
Я выключаю телевизор, я пишу тебе письмо
Про то, что больше не могу смотреть на дерьмо,
            Am
Про то, что больше нет сил,
                                   Em
Про то, что я почти запил, но не забыл тебя.

            Em
Про то, что телефон звонил - хотел, чтобы я встал,
Оделся и пошёл, а точнее, побежал.
          Am
Но только я его послал,
                                 Em
Сказал, что болен и устал, и эту ночь не спал.

Припев:
     D C     Em
     Я жду ответа -
   D C             Em
     Больше надежд нету.
     D  C          Em     D C
     Скоро кончится лето.
     Em
     Это…

А с погодой повезло - дождь идёт четвёртый день,
Хотя по радио сказали - жаркой будет даже тень.
Но, впрочем, в той тени, где я,
Пока и сухо и тепло, но я боюсь пока…

А дни идут чередом - день едим, а три пьём,
И, в общем, весело живём, хотя и дождь за окном.
Магнитофон сломался,
Я сижу в тишине, чему и рад вполне.

Припев:
     Я жду ответа -
     Больше надежд нету.
     Скоро кончится лето.
     Это…

За окном идёт стройка, работает кран,
И закрыт пятый год за углом ресторан.
А на столе стоит банка,
А в банке - тюльпан, а на окне - стакан.

И так уйдут за годом год, так и жизнь пройдёт,
И в сотый раз маслом вниз упадёт бутерброд.
Но, может, будет хоть день,
Может, будет хоть час, когда нам повезёт.

Припев:
     Я жду ответа -
     Больше надежд нету.
     Скоро кончится лето.
     Это…

     Я жду ответа -
     Больше надежд нету.
     Скоро кончится лето.
     Это…");

			Add("Ляпис Трубецкой - В платье белом", false,
@"  Вступление: Dm G C Am
 Dm            G           C         Am
Когда зимой холодною в крещенские морозы,
Щебечет песню соловей, и распускаются мимозы,
Когда взлетаешь к небесам и там паришь, пугая звезды,
А над окном твоим совьют какие-нибудь птицы гнезда.
Когда девчонка толстая журнал приобретает Мода,
И с ним, как будто юноши ей в школе не дают прохода,
Когда милиционер усатый вдруг улыбнется хулигану
И поведет его под руки, но не в тюрьму, а к ресторану.

  Припев:
   F           Fm                 Am
   Знай, это любовь, с ней рядом Амур крыльями машет,
   F           Fm              C                 G
   Знай, это любовь, сердце не прячь, Амур не промажет.

Когда мальчишка на асфальте мелом пишет чье - то имя,
Когда теленок несмышленый губами ищет мамки вымя,
Когда веселый бригадир доярку щиплет возле клуба,
Когда солдатик лысенький во сне целует друга губы,
Когда безродная дворняга взобраться хочет на бульдога,
Когда в купаловскую ночь две пары ног торчат из стога,
Когда седой профессор под дождем по лужам резво скачет,
А зацелованная им девчонка над пятеркой плачет...

  Припев


  Dm          F      G              Am
     Любовь зимой приходит в платье белом,
	 Весной любовь приходит в платье голубом,
	 Любовь приходит летом в платьице зеленом,
	 А осенью любовь приходит в золотом.

	 Любовь зимой всегда приходит в платье белом,
	 Весной любовь приходит в платье голубом,
	 Любовь приходит летом в платьице зеленом,
	 А осенью любовь приходит в золотом.

  Припев");
		}

		void AddFactor2()
		{
			AddRusKeysLines("Фактор-2 - Красавица (составлено вручную)",
@"ми минор
ля минор
си мажор
ми минор");
		}

		void AddAniLorak()
		{
			Add("Ани Лорак - Забирай (частично проверено)", false,
@"A7 
Dm 
A7 
Dm 
Gm 
A7 
Dm A7 
Gm A7 
Dm A7 Dm 
");

		}

		void AddElenaTerleeva()
		{
			Add("Елена Терлеева - Солнце", false,
@"Вступление: Gm | Bb | Eb | Cm
Gm Bb
Eb Cm D7
Gm
Bb
Eb
Cm D7
Gm
Bb
Eb
Cm D7
");

			Add("Елена Терлеева - Люби меня", false,
@"
G#
C
Fm
G#
C#
A#m
Cm
Fm
D#
C#
Cm
C#
C
");

		}

		void AddSavicheva()
		{
			Add("Юлия Савичева - Привет", false,
@"
 Вступление: Am | G | F | G > 2 раза

   Am     G        F      G
Магнит болит, не спит, мешает.
Убить, забыть, не быть, не знаю
  Dm     C     B    E
Тебя, тебя, тебя меняю
 F              E
На-на-на-на-на-на.

Уйди, замри, растай туманом.
Пойми, нельзя, нельзя обманом.
Хотеть, терпеть, реветь не надо,
Да! На-на-на-на-на.

	    F   Dm    E7         Am
	Привет!    Я даже не скучаю,
	Привет! Тебя не замечаю.
	Магнит болит, да, просто умираю -
	    F   Dm E7
	Привет!

Проигрыш = вступление

Тук-тук, тик-так, ты как? Расскажешь?
Ни друг, ни враг, все тот, все та же.
В ответ сойду на нет и даже...
Да! На-на-на-на-на.

	Припев

Проигрыш: Am | G  | F | G > 2 раза
          Dm | C  | B | E
          F  | Dm | E | E7
	    F
	
");

			AddRusKeysLines("Sarah Conor - Believe me (составлено вручную)",
@"соль минор
до минор
ми-бемоль мажор
си-бемоль мажор
ре мажор
соль минор
");
		}

		public void Add(string displayName, bool useAmericanStyle,
			string sequence)
		{
			Song song = new Song(displayName, sequence, useAmericanStyle, false);
			Songs.Add(song);
		}

		/// <summary>
		/// Добавляет песню, где каждая строчка - это тональность (или аккорд),
		/// записанный русскими буквами, например, 
		/// "ля минор
		/// до-диез мажор".
		/// Вместо переноса на новую строку можно использовать некоторые знаки,
		/// например, точку, вертикальную или горизонтальную черту, запятую, табуляцию и т.д..
		/// </summary>
		public void AddRusKeysLines(string displayName, string sequence)
		{
			Song song = new Song(displayName, sequence, false, true);
			Songs.Add(song);
		}
	}
}