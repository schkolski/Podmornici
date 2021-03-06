# Подморници
**Проектна задача по предметот Визуелно програмирање**
##Опис на играта##
Семинарската задача ја опфаќа играта Подморници попозната под името ["Battleship"] (http://en.wikipedia.org/wiki/Battleship_%28game%29). Целта на играта да ги погодите поставените бродови на компјутерот и да издвојувате победа. Компјутерот имат две нивоа лесно и тешко за кои што се дефинирани алгоритами кои што во продолжение ќе биде подетално објаснети. И компјутерот и играчот имаат по 4 бродови со големина 2, 3, 4 и 5. Компјутерот ги разместува бродовите рандом, истата опција е овозможена за играчот или да ги размести самостојно како што тој сака. Откако бродчињата ќе бидат наместени играта може да започне.

##Објаснување на имлементацијата на играта##
Играта се состои од четири прозорци (форми). Во првата форма играчот внесува име, избира ниво и клика на копчето за започнување нова игра.
![pocetok](https://cloud.githubusercontent.com/assets/12072224/7556361/750c6244-f76d-11e4-964e-2873d8700b75.png)

Со кликање на Нова игра се отвора вториот прозорец каде што корисникот треба да ги постави своите бродови на мапата. Има опција да бидат наместени случајно, самиот корисник да ги намести и доколку не е задоволен може да ги врати наместените бродови и да започне да ги реди одново. Со кликање на десен клик на бродовите може да ја менуваат својата положба од хоризонтално во вертикално и обратно.Доколку бродовите не се поставени во мапата или доколку има поклопивање истите се обојуваат црно со што му сугерираат на играчот дека не се добро поставени. Откако ќе бидат добро наредени односно нема да има поклопување играчот може да кликне на копчето започни игра.

 Лошо поставени бродови ![default](https://cloud.githubusercontent.com/assets/12381210/7554642/40759dc6-f730-11e4-8b0b-dddc69f1a4a1.png)
 
 Добро поставени бродови ![default](https://cloud.githubusercontent.com/assets/12381210/7554641/309bc7d6-f730-11e4-8416-4c03ebe41ce9.png)

Играта започнува со кликање на играчот на едно од полињата во деснтата мрежа при што доколку компјутерот има поставено брод квадратот се обојува црвено и играчот е повторно на потег, доколку промаши на потег е компјутерот. Доколку е погоден брод истиот се обојува со црна боја. Најдолу се соодвето поставени бродовите и во зависност од тоа дали се потопени или не се обојуваат во соодветна боја. Додадени се аудио фајлови за погодок на поле кое има брод, потопен брод и промашување.
![default](https://cloud.githubusercontent.com/assets/12381210/7554643/6063e87c-f730-11e4-9290-f8b793210a1d.png)

Играта завршува со потопување ан противничките бродови и соодветно се отвара последната форма, која што доколку сте победник изгледа :

![default](https://cloud.githubusercontent.com/assets/12381210/7554674/69ce0ffe-f731-11e4-9e8b-ab176b7f152e.png)

доколку изгубиде изгледа вака.

![default](https://cloud.githubusercontent.com/assets/12381210/7554670/5440e850-f731-11e4-8ebb-68a469ac2e4f.png)

Соодветно можете да започнете нова игра и да се вратите дома за да го променете името на играчот. 

**Пријатна игра !!!**

##Oпис за изворниот код##

Семинарската задача се состои од шест класи и тоа Brod, Game, Konfeta, Mapa, MapaBot, MapaIgrac. 

Во класата Brod се чуваат податоци за големината на бродот, Насоката која што корисникот може да ја менува, Координати од соодветната мапа (мрежа) тука се поставени само крајните леви  координати и со помош на големината ги добиваме останатите координати, се чуваат и пиксели X и Y па во зависност од тоа каде кликнал корисникот односно кои пиксели одредуваме кое поле од мапата го одбрал, се чуваат и бројот на погодоци за да знаеме дали бродот е потонат како и соодветните слики и аудио фајлови потребни за играта.

Методот гагај бот извршува алгоритни за гагање доколку нивото е лесно или тешко. Лесно ниво значи дека компјутерот пука рандом, но доколку нивото е тешко тогаш ја користиме листата на погодоци како помошна листа за чување на точки во кои што имало погодок. При тоа доколку во даден момент немаме никаков погодок гагаме рандом, и доколку се случи погодок истиот го регистрираме.Ако имаме регистрирано погодоци преку методот земи околина 

```cSharp
	private List<Point> zemiOkolina(List<Point> lst)
        {
            HashSet<Point> result = new HashSet<Point>();
            foreach (Point p in lst)
            {
                foreach (Brod b in mapaIgrach.Brodovi)
                {
                    if (b.tukaSum(p.X, p.Y) && !b.potopen())
                    {
                        foreach (Point q in zemiSlobodniSosedi(p)) 
                        {
                            result.Add(q);
                        }
                    }
                }
            }
            return result.ToList();
        }
``` 

ја земаме околината околу точките на погодок. При оваа метода се извршува уште една проверка не се земаат околните точки од точките на даден погодок доколку погодокот е во моментално потонат брод. Оваа околина може да биде бразна па затоа ни треба услов дали да земиме точка од неа или од останатите точки кои што се слободно. Во земената околина се гаѓа рандом. На крај од оваа метода ја бришиме точката каде што компјутерот пукнал од множеството слободни точки.

``` cSharp
	
	public void GagajBot()
        {
            Point gaganje = Point.Empty;

            if (nivo == Nivo.lesno)
            {
                gaganje = pukajRandom(slobodni);
                pukaj(gaganje);
            }
            else if (nivo == Nivo.tesko)
            {
                if (pogodoci.Count == 0)
                {
                    gaganje = pukajRandom(slobodni);
                    
                    if (pukaj(gaganje))
                    {
                        pogodoci.Add(gaganje);
                    }
                }
                else
                {
                    List<Point> okolinaZaGaganje = zemiOkolina(pogodoci);
                    if (okolinaZaGaganje.Count != 0)
                        gaganje = pukajRandom(okolinaZaGaganje);
                    else gaganje = pukajRandom(slobodni);

                    if (pukaj(gaganje))
                    {
                        pogodoci.Add(gaganje);
                    }
                }
            }
            slobodni.Remove(gaganje);
        }

```

Во класата Game се чуваат податоци за мапата на играчот односно објект од класата MapaIgrac и мапа на компјутерот, истотака се чува ниво (тешко, лесно) како и листа на слободни координати за компјутерот да не ги гага полињата кои што предходно биле гаѓани, се чува и последниот погодок кој што ни е потребно за алгоритмот за гагање на компјутерот при тешко ниво.

Класата Kofneta користи како помошна класа која се корсти за алгоритмот за гаѓање на компјутерот при тешко ниво.

Во класата Mapa се чува матрица од енумерација Sostojba која што ни ги претставува полињата во мапата односно дали има брод на нив, дали се погодени , промашени , или слободни и може да се гаѓа. Истота така се чува и листа од брододови во која што се додаваат соодветните бродови кои што се наоѓаат на мапата, пред да бидат додадени истите на мапата се прави проверка. Во методот пукај  се проверува дали на соодвеното поле има брод, или нема брод и соодветно се менува неговата Состојба.

Класите MapaBot и MapaIgrac наследуваат од класата Mapa со тоа што единствениот метод кој што се разликува е цртањето. Разликата е во тоа што корисникот треба да има можност да ги гледа каде се наоѓаат неговите бродови, а да не може да ги гледа на компјутерот додека не гаѓа.


##Изработиле##

Евгенија Стеваноска бр. на индекс 131033

Кристијан Спировски бр. на индекс 126035

Миланчо Трајановски бр. на индекс 126019
