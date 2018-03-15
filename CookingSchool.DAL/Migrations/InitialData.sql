


--składniki
DECLARE @CurrentDate DATETIME;
SET @CurrentDate = GETUTCDATE();

INSERT INTO [dbo].[Ingredient](Name, CreatedOnUtc, ModifiedOnUtc)
						VALUES  ('Kurczak', @CurrentDate, @CurrentDate ),
								('Wołowina', @CurrentDate, @CurrentDate ),
								('Wieprzowina', @CurrentDate, @CurrentDate ),
								('£osoś', @CurrentDate, @CurrentDate ),
								('Tuńczyk', @CurrentDate, @CurrentDate ),
								('Krewetka', @CurrentDate, @CurrentDate ),
								('Kalmar', @CurrentDate, @CurrentDate ),
								('Ośmiornica', @CurrentDate, @CurrentDate ),
								('Brokuł', @CurrentDate, @CurrentDate ),
								('Ryż', @CurrentDate, @CurrentDate ),
								('Kasza', @CurrentDate, @CurrentDate ),
								('Papryka', @CurrentDate, @CurrentDate ),
								('Pomidor', @CurrentDate, @CurrentDate ),
								('Sałata', @CurrentDate, @CurrentDate ),
								('Pieczarka', @CurrentDate, @CurrentDate ),
								('Cebula', @CurrentDate, @CurrentDate ),
								('Ziemniak', @CurrentDate, @CurrentDate ),
								('Banan', @CurrentDate, @CurrentDate ),
								('Jabłko', @CurrentDate, @CurrentDate ),
								('Pomarańcz', @CurrentDate, @CurrentDate ),
								('Makaron', @CurrentDate, @CurrentDate ),
								('Gruszka', @CurrentDate, @CurrentDate ),
								('Cukinia', @CurrentDate, @CurrentDate ),
								('Koperek', @CurrentDate, @CurrentDate ),
								('Kapusta', @CurrentDate, @CurrentDate ),
								('Ogorek', @CurrentDate, @CurrentDate ),
								('Marchew', @CurrentDate, @CurrentDate ),
								('Pietruszka', @CurrentDate, @CurrentDate ),
								('Karczoch', @CurrentDate, @CurrentDate ),
								('Batat', @CurrentDate, @CurrentDate ),
								('Morela', @CurrentDate, @CurrentDate ),
								('Bakłażan', @CurrentDate, @CurrentDate )
								


INSERT INTO [dbo].[Author] (Name, Surname, Job, City, Age, CreatedOnUtc, ModifiedOnUtc)
					VALUES ('Jan', 'Bollek', 'Analityk', 'Warszawa', 32, @CurrentDate, @CurrentDate),
						   ('Piotr','Oblak','Informatyk','Kraków',23,@CurrentDate, @CurrentDate),
						   ('Katarzyna','Popis','Kucharka','Szczyrk',28,@CurrentDate, @CurrentDate),
						   ('Antoni','Kowalski','Kierowca','Poznań',31,@CurrentDate, @CurrentDate),
						   ('Beata','Konopka','Księgowa','Gdańsk',33,@CurrentDate, @CurrentDate),
						   ('Piotr','Walczak','Analityk','Poznań',45,@CurrentDate, @CurrentDate)
--autorzy po kilka przepisów


INSERT INTO [dbo].Recipe( Title, [Description], MealTypeId, AuthorId, CreatedOnUtc, ModifiedOnUtc, ImageName)
			      VALUES('Jajka po szkocku','Jajka po szkocku, czyli jajka zawinięte w mięso mielone to topowe danie kuchni brytyjskiej. Scotch egg są popularną przekąską spożywaną szczególnie na zimno. Mimo wszystko, dla mnie wersja na ciepło jest zdecydowanie lepsza. Jajka po szkocku powinno się smażyć w głębokim tłuszczu, jednak postanowiłam je nieco odchudzić i upiekłam w piekarniku oraz podałam z chrzanem i pieczywem.' , 1, 4, @CurrentDate, @CurrentDate,'pomChlod.jpg' ),
						('Makaron w sosie serowym ze szpinakiem' ,'Na początku przygotowujemy szpinak. Masło rozpuszczamy na patelni i wkładamy na nią posiekany czosnek oraz liście szpinaku. Kiedy szpinak straci swoją objętość, doprawiamy całość gałką muszkatołową, sokiem z cytryny, solą oraz pieprzem.' , 7, 5, @CurrentDate, @CurrentDate,'SalatkaKurczak.jpg' ),
						('Sałatka Gyros' ,'Sałatka Gyros u niektórych z Was jest obowiązkową pozycją w imprezowym menu. Ja natomiast robię ją dość rzadko, a dlaczego? Sama sobie się dziwie. Jest smaczna, pożywna i smakuje każdemu! Sałatkę układa się warstwami – od czego zaczniecie zależy tylko od Waszej wyobraźni!' , 8, 6, @CurrentDate, @CurrentDate,'spagMalze.jpg' ),
						('Kurczak w sosie pomarańczowym z sezamem' ,'Kurczak w sosie pomarańczowym z sezamem to danie dla tych, którzy lubią niebanalne smaki oraz połączenie mięsa z owocami. Do przepisu użyłam czerwonych, słodkich i dojrzałych pomarańczy sycylijskich. Jeżeli użyjecie innych, bardziej kwaśnych, dodajcie więcej cukru do do sosu', 6, 4, @CurrentDate, @CurrentDate,'szaszlyk.jpg' ),
						('Carpaccio z wędzonego łososia' ,'£ososia kocham pod wszelkimi postaciami. Na surowo, wędzonego czy pieczonego. To zdecydowanie mój smak. Po nowym roku przywiozłam pysznego, wędzonego łososia z nad morza – musiałam zrobić z niego carpaccio Kilka chwil i mamy smaczne i wykwintne danie!' , 2, 5, @CurrentDate, @CurrentDate,'tatar.jpg' ),
						('Zielone tagliatelle mocno brokułowe' ,'Pychotkowane to danie, które się robi w 10 minut, czyli tyle, ile się gotuje makaron i brokuły.Kiedy po znojnym dniu, pełnym pracy, ochota na coś pysznego, ale naprawdę pysznego, to jest właśnie to! W dużym garnku nastawiam wodę na makaron - solę i wlewam łyżkę oliwy - dzięki temu się nie będzie sklejał.' , 7, 2, @CurrentDate, @CurrentDate,'klopsMakaron.jpg' ),
						('Lazania z cukinii i mielonego mięsa' ,'Obraną cebulę pokrój na cienkie piórka. Obrany ząbek czosnku pokrój na cienki plasterki. Natkę przebierz, usuń grube łodyżki, listki drobno posiekaj. Umyte i osuszone cukinie pokrój na cienki pasy - najłatwiej zrobisz to za pomocą obieraczki do warzyw. Plastry cukinii włóż do wysmarowanego odrobiną oleju naczynia żaroodpornego, lekko posól, skrop olejem i wstaw do piekarnika nagrzanego do 230 stopni na 8-10 minut - wyjmij, kiedy plastry cukinii zaczną się przypalać na brzegach. Ostaw do wystygnięcia.' , 7, 3, @CurrentDate, @CurrentDate,'kurczakCaly.jpg' ),
						('Gyros z piersi kurczaka' ,'Na patelni rozgrzewam silnie łyżkę oliwy i kiedy zaczyna dymić, wkładam mięso razem z marynatą - smażę na dużym ogniu, cały czas mieszając przez 3-4 minuty - kawałki mięsa powinny zacząć się lekko przypalać - wtedy zaś z przypraw wydobędzie się ich cały aromat.' , 6, 5, @CurrentDate, @CurrentDate,'losos2.jpg' ),
						('Kotleciki z jajek i kaszy jaglanej ' ,'Kotleciki z jajek i kaszy jaglanej są pyszne, lekkie i zdrowe. Do tego bardzo niedrogie. Mają, mimo swojej prostoty, bardzo dobry smak. Kasza jaglana i natka pietruszki wszystko wspaniale łączą. Podawaj z pieczarkami w śmietanie, z sosem pomidorowym lub w towarzystwie sałaty czy surówki o wyraźnym smaku.' , 6, 1, @CurrentDate, @CurrentDate,'łososRzodk.jpg' ),
						('Sałatka z brokułami i serem feta' ,'Do (najlepiej przezroczystej) miski wkładać kolejno: brokuł ugotowany na półmiękko w osolonej wodzie i podzielony na różyczki; kukurydzę, szynkę pokrojoną w kostkę, pomidory pokrojone w kostkę. Całość zalać przygotowanym sosem. Na wierzch rozłożyć fetę pokrojoną w kostkę i posypać suszoną bazylią.' , 8, 2, @CurrentDate, @CurrentDate,'paprykaFaszer.jpg' ),
						('Boski szpinak! (sałatka)' ,'Do miski wrzucić szpinak, co większe liście porwać. Fetę pokruszyć na drobne grudki, dodac do liści. Pomidory pokroić w paseczki, też wrzucić do środka. To samo ze słonecznikiem. Wszystko odrobinę posolić i popieprzyć, dodac troche oliwy z pomidorów, wymieszać. Jeśli będzie zbyt suche, dodać oliwy. Gdy będzie już takie jak ma być, pokroić szynkę w cienkie paski i posypać nimi sałatkę.' , 8, 3, @CurrentDate, @CurrentDate,'pizzaRucolla.jpg' ),
						('Ryba po indonezyjsku' ,'Sól, pieprz, zmiażdżony czosnek i wodę wymieszać i natrzeć tym rybę. Ułożyć w lekko natłuszczonym naczyniu żaroodpornym i piec przez 15 minut w temperaturze 180 stopni. W tym czasie wymieszać oliwe, sos sojowy, sok z cytryny i chilli. Wyjąć rybę i polać sosem. Piec kolejne 15 minut. Podawać z ryżem i sałatką.' , 6, 5, @CurrentDate, @CurrentDate,'vegeSalad.jpg' )

						


--RecipeIngredient



DECLARE @ingredientCount INT = 0;
SELECT @ingredientCount = COUNT(*) FROM [dbo].[Ingredient]

DECLARE @RecipeId INT = 0

-- Iterate over all recipes
WHILE (1 = 1) 
BEGIN  

  -- Get next recipeId
  SELECT TOP 1 @RecipeId = Id
  FROM [dbo].[Recipe]
  WHERE Id > @RecipeId 
  ORDER BY Id

  -- Exit loop if no more recipes
  IF @@ROWCOUNT = 0 BREAK;

  
  DECLARE @cnt INT = 0;
  DECLARE @IngredientPerRecipe INT = 0;
  SET @IngredientPerRecipe = ABS(CHECKSUM(NewId())) % 11

  WHILE @cnt < @IngredientPerRecipe
	BEGIN
	
	DECLARE @ingredientId INT = 0;
	SELECT @ingredientId = ABS(CHECKSUM(NewId())) % @ingredientCount

	INSERT INTO [dbo].[RecipeIngredient] (IngredientId, RecipeId)
	VALUES (@ingredientId, @RecipeId)

   SET @cnt = @cnt + 1;
	END;


END