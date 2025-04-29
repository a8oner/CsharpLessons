

using System;
using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.Extensions.Primitives;

namespace ProjectExample
{
    class Program2
    {
        //Bir değişken class scope içerisinde tanımlanıyorsa buna global değişken denir
        int global = 21; //gloabl değişken
        static void Main(string[] args)
        {
            //    Console.WriteLine("Hello world");
            //Console.WriteLine(args[0]);
            //Console.WriteLine(args[1]);
            //region


            //todo yorum satırında Kritik noktalara erişimi sağlar (View>task list seç 
            //      Console.WriteLine(typeof(int).IsPrimitive);  //Primitive kontrolü

            /*
             keyword: static bir kword'dür , 
             keyword'ler değişken olarak tanımlanamazlar ama @ başa alınarak kullanılabilirler 
             static @static; kullanılabilir 
            normal değişkenlerin de başına eklenebilir fark oluşturmaz
              */
            #region  DEGİSKENLER

            char x = 'a'; //'abc' olmaz tek karakter olmalı
            string y = "Azat";  // "A" olabilir
            float f = 3.14f; // ya da 3.14F 
            double d = 3.14; //ya da 3.14D ya da 3.14d double'da harf bırakmak zorunda değiliz
            decimal de = 3.14m; //ya da 3.14M 

            //Tuple türüyle değer atama

            (int yas, string ad, bool durum) kisi = (23, "Azat", true); //bu şekildde tanımlamaya Tuple türüyle değer atama denir
            kisi.durum = false;

            (int e, int f) deneme;
            deneme = (21, 23);

            int literal = 1_000_000; //buna literal düzenleme denir , daha güzel okunur

            //default keywordü: içerisine verilen türün varsayılan değerini geri döndürür
            bool w = default(bool);
            int r = default(int);
            string t = default(string);
            char u = default(char);
            //add watch ile bunların default değerini görebilirsin
            bool o = default; //bu şekilde de gösterebiliriz
            //Main içerisinde oluşturulan değişkenlerin ilk değerlerini manuel atmaya özen gösteriniz

            const int sbt = 1;
            //const'lar tanımlama aşamasında değerleri atanmalı, aksi takdirde hata alınır
            int ilk = 1, diger = 2;
            //deep copy neticesinde eldeki veri çoğalır
            #endregion

            #region OBJECT
            /* OBJECT TÜRÜ
            object:Tüm türler varsayılan olarak object türlerden türerler
            object : referans türlü bir değişkendir
            lakin deger türlü degerleri de karşılayabilir
            Object değişkenler ilgili verileri RAM'da object türde tutarlar
            aynı zamanda object içerisinde verileri öz türünde tutarlar . string ise string gibi...
            object içinde veri kaydettik buna "Boxing" denir çıkarmaya da "Unboxing"

            */
            object adi = "Azat";
            //herhangi bir değer object türe assign(eşitleme)yapılıyorsa buna Bxing denir
            //object bir değişkeni kendi türünde kullanabilmemiz için onu unboxing yapmamız gerek. örneğin sayısal değeri işlemde kullanabilmemiz için onu unboxing yapıp işleme tabi tutabiliri
            /* CAST Operatörü
             Boxing edilmiş bir veriyi kendi türünde elde etmesini sağlayan bir operatördür
            int a=5;
            object b=a; //burda boxing yapıldı
            (int)b; //cast parantez'dir. cast b değişkeni içerisindeki değeri bana int olarak ver demektir

             */

            #region Casting
            object _yas = 23;
            Console.WriteLine((int)_yas * 2);//unboxing edilip işleme tutuldu
            int yas = (int)_yas; //unboxing
                                 //unboxing yapabilmek için boxing'teki original türü ne ise o türden unboxing yapılır. ör: int ise (int)ile unboxing yapılır

            #endregion
            //var-object arasındaki fark:
            //var bir keyword iken object ise bir türdür. var atanan değerin türüne bürünürken, object atanan değeri Boxing yaparak object'te dönüştürür


            #endregion

            #region dynamic
            /*
             var derleme(compile/development) aşamasında değerin türüne bürünürken, dynamic ise runtime'de verilen değerin türüne bürünecektir
             var ile dynamic benzer görevler görür
             dynamic atanan türe dönüşebilmesi için uygulamanın çalıştırılması gerek
            
            dynamic a=5;
            var a=5;
             */
            //dynamic keywordü runtime'da türü belirleyecektir lakin kararlı davranmayacaktır
            dynamic deger = "Azat";
            //        Console.WriteLine(deger.GetType());
            deger = 3.14; //diğer keyword'de hata çıkması beklenirken dynamic'te çıkmadı
                          //       Console.WriteLine(deger.GetType());
            #endregion

            #region Önemli **********
            /*
             Uzaktan gelen veriler var keywordu ile karşılanmaz
            Cünkü var keywordu tanımlandığı esnada verinin atanmasını ister!!
            onun için dynamic kullanılır
             */
            #endregion

            #region  Metinsel İfadelerin Diğer Türlere Dönüşümü
            //Dönüşüm yapılacak verinin türüne uygun bir hedef tür belirlenmelidir
            #region Parse Metodu
            //Parse metodu sadece string dataları hedef türe dönüştürürken kullanılır!
            string x1 = "123";
            int x2 = int.Parse(x1);
            //      Console.WriteLine(x2);
            //      Console.WriteLine(int.Parse(x1));

            string ogrenciMi = "true";
            bool ogrenciMi2 = bool.Parse(ogrenciMi);
            Console.WriteLine(ogrenciMi2);
            #endregion

            #region Convert Fonksiyonları
            //her bir tür arasındaki dönüşümü yapar
            string x3 = "25";
            int x4 = Convert.ToInt32(x3);

            bool b = false;
            string st = Convert.ToString(b);
            //    Console.WriteLine(st);

            #endregion

            #region ToString Fonksiyonu
            float f1 = 35;
            string f2 = f1.ToString();

            #endregion

            #endregion

            #region Sayısal ifadelerin tür dönüşümü
            /*Bir sayısal türün alt türüne bir veriyi dönüştürdüğümüzde eğer ki o veri o alt türün değer aralığına girmiyorsa Veri kaybı olur
            37000 değerli bir int değişkenini byte'a dönüştürdüğümüzde 255'e bölerek modunu alır ve kalanı yansıtır
            daha küçüğe dönüştürmeye BİLİNÇLİ dönüşüm daha büyük bir türe dönüşüme BİLİNÇSİZ dönüşüm denir
            örneğin int'den float'a bilinçsiz dönüşümdür çünkü float daha 
             */
            #region Bilinçsiz Tür Dönüşümü
            //Bir sayısal türün kendisinden daha geniş aralıkta başka sayısal türe atanması bilinçsiz tür dönüşümüdür
            int a1 = 300;
            float f3 = a1; //burda tür dönüşümü gerçekleşti.lakin burdaki tür dönüşümü bizim irademizle olmadı

            #endregion

            #region Bilinçli Tür Dönüşümü
            int xa = 60000;
            short xa1 = (short)xa; //Cast operatörü (parantez) kullanıldı
                                   //     Console.WriteLine(xa1);

            int xb = 6000;
            short s = (byte)xb; //int'den byte'a bilinçli,çünkü int byte2dan büyük. byte'dan short'a bilinçsiz,short byte'dan büyük

            #region checked
            // bilinçli tür dö. esnasında bir veri kaybı söz konusu olursa runtime'da bizleri uyaracak olan bir kontrol mekanizmasıdır
            checked
            {
                int aa = 50;
                byte bb = (byte)aa;
                //     Console.Write(bb);
            }
            unchecked //hataya izin verir,veri kaybı olur. normal defaault kodudur
            {
                int aa1 = 500;
                byte bb1 = (byte)aa1;
                //  Console.Write(bb1);
            }

            #endregion

            #endregion
            #endregion

            #region bool türünün sayısal türe dönüşümü
            bool i0 = true;
            int i = Convert.ToInt32(i0);
            Console.WriteLine(i);
            #endregion
            #region sayısal türlerin bool türüne dönüşümü
            int ii = 1;
            bool bi = Convert.ToBoolean(ii);
            Console.Write(bi);
            #endregion

            #region char ifadelerinin sayısala dönüşümü
            //ASCII:Bilgisayardaki herbir karakterin sayısal bir karşılığı vardır buna ASCII kaynak kodu denmektedir
            char c = 'a';
            int ci = (int)c; //Cast operatörü kullanıldı.Cast operatörü > unBoxing,bilinçli tür dönüşümü ve char ifadelerinin sayısala dönüşümünde kullanıldı
            Console.WriteLine(ci);
            #endregion

            #region sayısal ifadelerin char'a dönüşümü
            int oascii = 111;
            int Oascii = 79;
            char o1 = (char)oascii; Console.WriteLine(o1);
            char O1 = (char)Oascii; Console.WriteLine(O1);
            #endregion

            #region Aritmatik operatörler
            /*İki farklı türde sayısal değer üzerinde yapılan aritmetik işlem neticesinde sonuç büyük olan türde dönecektir(int>short=>cvp int döner)
            double>int , int>byte , 
            byte'da istisna var . iki byte arasında yapılan aritmetik işlem sonucunda sonuç int döner
             */
            #endregion
            #region Mantıksal operatörler
            /*
             || : veya operatörü şartlardan herhangi birinin olması yeterlidir
             ^ : ya da operatörü ya sen ya da diğer sen geleceksin. yani şartlardan sadece biri olmalı
            ++1: öncelikle +1 artırır , ardından i edğerini döndürür
            i++: öncelikle i değerini döndürür sonra i'yi 1 artırır
            int i=10;
            CW(i++); Çıktı: 10 Bellek: 11, CW(++i);Çıktı: 11 Bellek: 11
             */
            int A = 5;
            int B = A++;
            Console.WriteLine(A); // cevap 6
            Console.WriteLine(B); // cevap 5

            int i1 = 5;
            int i2 = ++i1;
            int i3 = i1;
            i2 = ++i2;
            Console.WriteLine(i1); //cevap 6
            Console.WriteLine(i2); //cevap 7
            Console.WriteLine(i3); //cevap 6

            string isim = "Azat";
            string isim2 = "Ahmet";
            bool cevap = isim == isim2;
            bool cevap2 = isim.Length > isim2.Length;
            bool cevap3 = isim != isim2;

            #endregion

            #region Ternary Operatörü
            /*KURALLAR
           1)  Dönecek değerler aynı türden olmalı
            şart ? durum1 : durum2;
           2)  Polymorfizm kurallarına göre birbirinden türeyen değerler artık desteklenmektedir
             */
            #region Birden Fazla Condition Uygulamak
            int yasi = 25;
            //Yaşı 25'den küçük olanlara A, 25 olanlara B ve 25'den küçük olanlarlara C değerini döndüren ternary operatörü oluşturalım
            string sonuc = yasi < 25 ? "A" : yasi == 25 ? "B" : "C";
            int sayi1 = int.Parse(Console.ReadLine());
            //Console.readline komutu kullanıcıdan string bir değer ister

            #endregion
            /*
             * Atama operatörü(Assign operatörü) 
            int a=5; bukadar!!
             */
            #endregion

            #region Cast Operatörü
            //Genellikler tür dönüşümlerinde kullanılan bir operatördür
            //1.Boxing->Unboxing
            object ou = 123;
            int ou1 = (int)ou;

            //2.Bilinçli Tür Dönüşümü
            int ou2 = 5;
            short ou3 = (short)ou2;

            //3.Char->int | int->Char (ASCII)
            int ascii = 93;
            char cp = (char)ascii;
            #endregion

            #region sizeof Operatörü
            //Verilen türün bellekte kaç byte kapladığını int olarak geriye döndürür
            Console.WriteLine("int: " + sizeof(int));
            #endregion
            #region typeof Operatörü
            //typeof operatörü verilen değerin type'ını getirir
            Type t2 = typeof(int);
            Console.WriteLine(t2.Name);
            #endregion
            #region default Operatörü
            //belirtilen türün default değerini döndüren operatördür.Default değerler,her tür için yazılım tarafından tganımlanmış bir varsayılan değer demektir
            // sayısal=0, bool=false, string=null, char= \0, referans= null 
            int d1 = default; int d2 = default(int); //iki değere şekildeki gibi default değer atandı
            #endregion
            #region is null Operatörü
            /* is null operatörü sadece null olabilen türlerde kullanabiliriz.
             Değer türlü değişken: not nullable(int,char,bool) . int is not nullable
             Referans Türlü Değişken: nullable . string is nullable
             */
            #endregion

            #region as Operatörü
            /*
             Cast operatörünün UnBoxing işlemine alternatif olarak üretilmiş bir operatördür
            >Cast'ta türüne uygun bir şekilde cast edilmesi gerekiyor!eğer ki farklı bir türde cast edilirse hata verecektir
            >as'de türüne uygun bir şekilde as edilmesi zaruri değildir. eğer ki tür uygunsa unboxing işlemi başarılı yapılacak. yok eğer tür uygun değilse Hata vermeyecek null değer döndürecektir..
            Type y= x as Type : as operatörü tür uygun olmadığı takdirde null döndüreceği için as operatörü değer türlü değişkenlerde kullanılmaz!!
            referans türlerdeki değişkenlerle çalışabilir..!!!
             */
            object l = "Ahmet";
            string m = (string)l; //Cast operatörü

            object l1 = "Azat";
            string m1 = l1 as string;
            Console.WriteLine(m1);

            #endregion
            #region ?(Nullable) Operatörü
            /*
            C# prog. dilinde değer tür. değişkenler normal şartlarda null değer alamazlar(not nullable)
            Bir değer türlü değişkenin null değer alabilmesi için(yani nullable olabilmesi için) ? operatörünün kullanılması gerekmektedir
             */
            int? n = null;//normalde hata veriyordu ? ile hata kalktı
            bool? n1 = null;
            Console.WriteLine(n is null);

            //ÖNEMLİ*****, as 
            object w0 = 123;
            int? w1 = w0 as int?;
            /*
             as operatörünü normalde sadece nullable olanlarda(referans türlü)kullanabiliyorduk.örnekte int(değer türlü -not nullable) ile kullanılmak istenmiş 
             as operatörünü bu şekilde kullanabilmemiz için int? ile kullanmalıyız
            */
            #endregion
            #region ??(Null-Coalesing) Operatörü
            /*
             a?? "Merhaba" a değişkeninin değeri null değilse a yazdır , null ise Merhaba yazdır
             Null Coalescing operatöründe her iki taraftaki değişken aynı türden olmalı
             */
            string v = null;// örneğin burda Console.WriteLine(v??3);diye bir şey yapamayız


            #endregion
            #region ??= Operatörü (Null-Coalescing Assignment)
            string g = null;
            Console.WriteLine(g ??= "Merhaba");//g'nin değeri null ise Merhaba yazdır ver Merhaba değerini g'ye ata. Eğer ki null değilse g'yi yazdır
            int? id = null;
            id ??= 1;//id null ise 1 değerini ata, yok eğer değilse değerini koru
            #endregion

            #region Switch-case
            //Switch case sadece eşitlik durumu check edilecekse o zaman switch kullanılabilir.büyüklük,küçüklükte kullanılamaz
            string ad = "Ahmet";
            switch (ad) //switch parantezindeki kontrol edilen değer değişken olabilirken case'de kontrol edilen değişken olamaz
            {
                case "Ahmet":
                    Console.WriteLine("Adi Ahmet");
                    break;

                case "Ayşe":
                    Console.WriteLine("Adi Ayşe");
                    break;

                default:
                    Console.WriteLine("Hiçbir seçenek uyuşmadı");
                    break;
            }
            //Eşitliğin yanından farklı şartlarida değerlendirmek istiyorsak when'i kullanabiliriz
            #region when
            int satisTutar = 1000;
            switch (satisTutar)
            {
                case 1000 when (3 == 5):
                    break;

                case 1000 when (3 == 3):
                    break;
            }
            #endregion
            #region goto 
            //Farklı eşitliklerde aynı kodu çalıştıracaksak eğer kod tekrarına girmemek için goto keywordu ile şu kodu çalıştır diyebiliyoruz. ,
            int vv = 10;
            switch (vv)
            {
                case 5:
                    Console.WriteLine(i * 10);
                    break;
                case 6:
                    Console.WriteLine(i);
                    break;

                case 7:
                    goto case 5; //Dikkat goto kullandığımızda break kaldırılır

                case 10:
                    goto case 5; // Dikkat goto kullandığımızda break kaldırılır

                    /*
                     case 7:
                     case 10: //her iki case'de gidilecek hedef aynı olduğundan bu şekilde de gösterebiliriz
                     goto case 5; 
                     */

            }

            #endregion
            #region Switch Expression
            int io = 10;
            string isimm = io switch
            {
                5 => "Hilmi",
                var c0 when c0 == 7 && c0 % 2 == 1 => "Rıfkı",
                int c1 when c1 == 7 && c1 % 2 == 1 => "Rıfkı",
                9 => "Gençay",
                var c0 => "Hiçbiri"  //default: hiçbirinin olmadığı durumda default tanımlamasına karşılık gelecektir.

            };
            #endregion
            #region Tuple Patterns
            int s1 = 10;
            int s2 = 20;
            string mesaj = (s1, s2) switch
            {
                (5, 10) => "5 ile 10 değerleri",
                (10, 20) => "10 ile 20 değerleri",
                var k when k.s1 % 2 == 1 || k.s2 == 10 => "tek sayı ile 10 değerleri",


            };
            Console.WriteLine(mesaj);
            #endregion

            #endregion

            #region If Yapisi
            // if-else if yapısında yukardan kod çalışmaya başlar true değerine rastladığında onu çalıştırır altta başka bir true varsa dahi pas geçer
            // Ama if- if yapısında yukardan aşağı doğru tüm if koşullarını çalıştırır. böyle bir durumda birden fazla true değeri çıkması dahilinde her biri ayrı ayrı çalışır

            #endregion

            #region Pattern Matching

            #region Type Pattern
            /*
             Object içerisindeki bir tipin belirlenmesinde kullanılan is operatörümüm desenleştirilmiş(daha kolay kullanılabilir) halidir.
            is ile belirlenen türün direkt dönüşümünü sağlar
             */
            object X = 125;
            if (X is string XX) //X string ise XX'i string olarak sana döndürdü.yani otomatik cast yapıldı
                Console.WriteLine($"x değişkeni string tipindedir");
            else if (X is int xx)
                Console.WriteLine($"x değişkeni int tipindedir");

            object Y = "Azat";
            if (Y is string Yy)
            {
                Console.WriteLine(Yy);
            }
            else if (Y is int yy)
            {
                Console.WriteLine(yy);
            }

            #endregion
            #region Constant Pattern
            //Elimizdeki veriyi sabit bir değer ile karşılaştırabilmemizi sağlar
            object l0 = 123;
            if (l0 is 123) { } //l0 123 müdür? 
            if (l0 is int) { } //l0 int midir?

            #endregion
            #region Var Pattern ÖNEMLİ
            //Eldeki veriyi 'var' değişkeni ile elde etmemizi sağlamaktadır.
            object h = "Diyarbakır";
            if (h is var hh)//burda h var türünde hh'ye dönüştürüldü
                            //var: verilen değerin türüne bürünen bir keyword.. runtime'da bürünme işlemini gerçekleştirmektedir.
            {
                Console.WriteLine(hh);
            }
            //normal var derleme sürecinde türü belirlenirlen Var pattern ise runtime sırasında türü belirlenir
            //dynamic'de de runtime sırasında türü belli olurdu.
            //

            #endregion
            #region Recursive Pattern
            /*
             * Bu desen switch-case yapılanması üzerinde birçok yenilik getirmektedir
             * switch bloğunda referans türlü değişkenlerde kontrol edilebilmektedir
             * Ayrıca switch bloğuna when komutu ile çeşitli koşul niteliği kazandırılmıştır
             * Recursive pattern,case null komutu ile ilgili türün/referansin null olup olmamasını kontrol edebilmesinden Constant pattern'i kapsamaktadır
             *Recursive pattern tür kontrolü yaptığı için Type Pattern'i kapsamkatadır
             */
            #endregion
            #region Type ve Var Pattern üzerine Kritik
            object ss = "sndföbnds";
            if (ss is string a)
            {
                Console.WriteLine(a);
            }
            if (ss is var ba)
            {
                Console.WriteLine(ba);
            }
            /*
            bool result = ss is var ob; //ss is string ob olmuş olsaydı (type pattern)aşağudaki CW'de ob hata verecekti çünkü gelecek değer null olabilir.ama var ob dediğimiz zaman hata vermez çünkü ne olursa olsun var ile ata diyor, null olma şansı yok
            Console.WriteLine(ob);
            */
            #endregion
            #region Relational Pattern
            int number = 111;
            string result = number switch
            {
                < 50 => "50'den küçük",
                > 50 => "50'den büyük",
                50 => "50'ye eşit",
                //  _ => "Hiçbiri" , default değer
                //switch'de sadece eşitlik kıyaslamaları vardı relation pat. ile karşılaştırmayı da kullanabiliyoruz
            };
            #endregion
            #endregion

            #region Hata Kontrol Mekanizmaları
            try
            {
                int u1 = 0, u2 = 10;
                int u3 = u2 / u1;
            }
            catch (DivideByZeroException e0)
            {
            }
            catch (FormatException e1) when (3 == 3) //try-catch bloklarına when ile şart uygulayabiliyoruz
            {

            }
            catch (Exception e)
            {//Exception tüm hataları karşılayabilir. Exception diğer hata ayıklamalardan ayretten aşağı bırakılmalı
                Console.WriteLine("Mesaj: " + e.Message);
            }

            finally
            {
                //her iki durumda da çalışmasını istediğimiz kodları buraya yerleştiririz.her şekil (hata alınsa da alınmasa da) bu blok çalışır ve finally sonda olmalı
            }

            #region Mantıksal Hata
            //Mantıksal hataların çözümü zordur, bazen tek çözüm debug'dır.
            // Console.WriteLine(2*6);//2*5 yapacağına 2*6 yazmış bu mantıksal hatadır
            #endregion

            #endregion

            #region Döngüler
            #region For döngüsü
            int toplamSonuc = 0; //[1-40]arası çift sayılaın toplamı
            for (i = 1; i <= 40; i++)
            {
                if (i % 2 == 0)
                {
                    toplamSonuc += i;
                }
            }
            Console.WriteLine("Toplam Sonuç: " + toplamSonuc);

            /*
              int a = 10;
              for(int i = 0; a != 2 * i; i++) //burda ortaya konan şart i'den farklı!!!
              {
                  Console.WriteLine("Azaat");
              }
             */
            /*
             * for(; ; ;) sonsuz döngü
             * for(i=0; ;i++) sonsuz döngü
             * for (int i= 0, i2 = 0; i < 10 && i2 < 5; i2++, i++)//iki farklı değişken de tanımlanabilir.değişkenlerden biri dışarda da tanımlanabilirdi
             */
            #endregion
            #region While döngüsü
            //genellikle sonsuz döngülerde ya da süreci bilinmeyen durumlarda kullanılan bir döngüdür
            int _i = 0;
            while (_i < 2) //içeriye sadece şart koşulu yazılır
            {
                //  _i++; duruma göre buraya da yerleştirilebilirdi
                // Console.WriteLine(_i);
                _i++;
            }

            /*
             int i = 0, toplam = 0;
              while (i <= 100)
               {
               //i++;
               if (i % 2 == 1)
               toplam += i;
                  i++;
                }
             */


            #endregion

            #region do while Döngüsü
            int abc = 4;
            do
            {
                /*
                 * do while döngüsü önce kodu çalıştırır sonra şarta bakar
                 * do while döngüsünde şart true'da olsa false da olsa en az bir kere tetiklenecektir
                 */
            } while (abc < 10);
            /*Scope'suz döngüler
             for (int i = 0; i<10; i++)
             Console.WriteLine("Gençay Yıldız");|
             while (true)
             Console.WriteLine("");
             
             do
             Console.WriteLine("asdpasldö");
             while (true);
             */

            #endregion
            #endregion
            #region KeyWord-operatör farkı
            /*
             Keyword: Programlama dilinin ennn atomik parcalaridir diyebiliriz...
             Derleyici icin on tanimli olan, nerede hangi amaca hizmet edecegi belli ve kod icerisinde hangi noktalarda
             cagrilabilecegi/kullanilabilecegi kurallarla sinirlandirilmis olan anahtar sozcuklerdir......

             Keyword'lerin operatorlerle ne farki vardir?
             Operatorler esas olarak belirli bir operasyonu/eylemi ustlenen yapilardir.
             Keywordler daha genis kavramdirlar...
             is, typeof
             Operatörler esasında bir keyword'dür lakin her keyword operatör(+,==,..) değildir
             */
            /*
             * konseptli keywordler tek başına kullanılmazlar . konseptiyle (geriye kalan yapısıyla) beraber kullanılmak zorundadırlar
             * namespace , class , for , while, do while her biri bu türdendir
             /*
            Konseptsiz keywordler tek başlarına kullanılabilirler . 
            return,break,continue,goto .. gibi
            */

            #endregion

            #region Manevratik Komutlar
            #region break Komutu
            /*
             * break komutu sadece döngüler ve switch-case içerisinde kullanılabilir
             * Kullanıldığı yapıdan çıkış yapılmasını , kullanıldığı yapıyı(ilk çemberdeki yapıyı) sonlandırmaya yarayan bir keyword'dür
             */

            for (int ik = 0; ik < 5; ik++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 1)
                        break;
                    Console.WriteLine("i: " + i + "j: " + j);
                }
            }

            //Örnek
            //Kullanıcıdan 't' harfi girene kadar alınan sınırsız sayıda sayıyı toplayan ve sonucu ekrana yazdıran uygulamayı yazalım.

            int toplam = 0;
            while (true)
            {
                Console.WriteLine("Lütfen bir sayı giriniz.");
                string girilenDeger = Console.ReadLine();
                if (girilenDeger == "")
                {
                    Console.WriteLine("Toplam Sonuç: " + toplam);
                    break;
                }
                else
                {
                    toplam += int.Parse(girilenDeger);
                }
            }
            #endregion
            #region continue Komutu
            /*
             * Sade ve sadece dongulerden erisilebilen ve dongulerde kullanilabilen bir keyworddur.
             *Amac: Dongude bir sonraki tura gecilmesini saglar. Yani bir sonraki periyoda direkt gecis yaptirir.
             */

            //ÖRNEK . 1 ile 10arasında 7'nin katı olmayan sayıları ekrana yazdıralım

            for (int ik = 1; ik < 10; ik++)
            {
                if (ik % 7 == 0)
                    continue;
                Console.WriteLine();
            }

            #endregion
            #region return Komutu
            /*
             *Her yerde(metot icerisinde) kullanilabilir, erisilebilir bir keyworddur.
              Iki islevi gormektedir;
              1- Nerede cagriliyorsa cagrilsin bulundugu metottan cikis yapar. Yani
              metodu sonlandirir.
              2-İleride gorecegimiz metotlar konusunda geriye deger dondurme sorumlulugunuda
              ustlenen bir keyworddur.              ,
              return'den sonra hangi komut geliyorsa gelsin metot sonlanacagi icin ISLENMEYECEKTIR!!!!
             Console.ReadKey().KeyChar //tıklanan tuş komutu
             */

            #endregion
            #region goto Keywordu
            /*
             *Kodun senkranizasyonunu bozup, akisi ters istikamette almamizi saglayan bir manevratik komuttur.
             * switch case yapılanmasinda dahili olarak kullanilan bu komut, metot icerisinde heryerde kullanailbilir.
             * Geleneksel coderlar tarafindan pek sevilmeyen goto keywordu tavsiye edilmemektedir.
             * Teknik olarak programmi yavaslattigi soylenmektedir. Hatta yapilmis olan performans
               testlerini inceledigimizde bir nebze kayip ve yavaslik soz konusudur. Yani maliyeti diger durumlara
               nazaran oldukca fazladir.
             * goto keyworduyle senkronizasyonu bozup basa donme durumu bir donguyle ayni islemi yapmaya
               nazaran daha maliyetli olackatir...
             * "İyi bir c# programcisi, gerekmedigi surece kesinlikle goto anatar sozcugunu kullanmamalidir..."
               Sefer Algan
             * Diller gelistikce ve yuksek seviyede oldukca bu komutun kalmasi dogal bir surectir....
             */

            /*
            1'den 100'e kadar sayalım.
            int i = 1;
            X:
            Console.WriteLine(i++);
            if (i <= 100)|
            goto x;
             */

            #endregion
            #region Döngülerde Boş Scope Kullanmak İstemediğimiz Durumlarda ; (Noktalı Virgül) Operatörü İle Temiz Kod Yazımı
            /*
              for(;;);
              while(true);

              do;
              while(true);i
            // if(true); bu sonsuz döngü değildir. ama çalışır. gereksiz ayrıntı
             */
            #endregion

            #endregion

            #region Diziler-Arrays
            /*
             Diziler icerisinde birden fazla ayni turde deger tutabilen yapilardir.
             Prosedurel programlamanin temel veri kumeleridsir. Yani yazilimsal boyutta,
             yazilim adina RAM'de birden fazla degeri tek bir degisken altinda bir veri kumesi
             halinde tutabilirler....
             Diziler, veri kumleri olduklari icin, iclerindeki birden fazla veri uzerinde kumesel
             islemler yapmamizi saglayabilirler...
             Diziler, prosedurel prog. temel yapilari olduklari icin daha gelismis yapilar olan
             koleksiyonlarinda temelini teskil etmektedirler ve gelismelerine katkida bulunmaktadirlar.
             Diziler referans turlu degerlerdir. Yani nesnel yapilardir. Ozlerinde classtirlar...
             Yapisal olarak RAM'de Heap'te tutulurlar....  
            
            Dizi icerisine her turlu deger koyulabilir.
            Deger turlu-Referans turlu
            Bir dizi sade ve sadece tek bir turde
            deger alabilir.
            Dizi icerisine koyulan degerler islevsel
            olarak ayni mahiyette olmalidir.
            Ornegin; yas dizisine maas bilgisi
            ayni turde oldugu halde verilmemelidir.

            Diziler icerisine eleman/deger eklendikce
            bunlari serseri bir sekilde depolamaz
            duzenli bir sekilde sirali depolayacaktir.
            Dizilerde eklenen elemanlar index
            ismini verdigimiz numaralarla ardisik
            bir sekilde numaralandirilirlar...         
            index no: Her bir elemana verilen ardisik
            sayi. O'dan baslar n-1'e kadar gider.

            type[]a----->Dizi
            Bir degisken tanimlanirken turunun yanina bu operatoru koyarsak
            o degisken o turde bir dizi degiskeni olacaktir.
            Bu operatore INDEXER ismi verilmektedir.

            type[]name=new type[...] // son parantez=> dizinin alacağı eleman sayısı beliritlir
            new=>OOP. bir dizi nesnesi oluşturmamızı sağlar. 

             */
            /*Tek bir değişken altında birden fazla 'aynı türde'değeri toplamamızı sağlayan veri kümelerine dizi denmektedir
            Dizilerde tanımlama yaparken eleman sayısının bildirilmesi zorunluluğu bir sınırlılıktır
            Bir dizi tanımlanırken yapıldığı an bellekte o diziyi kullansak da kullanmasak da verilen eleman sayısı kadar alan tahsis edilir
            Kullanılmadığı halde diziler direkt olarak bellekten belirtilen eleman sayısı kadar alan tahsisinde bulunması bir sınırlılıktır
            Diziler alan tahsisi yapıldığında ilgili alanlara turune göre uygun default(string=>null,int=>0,bool=>false) değerler atarlar
             */
            int[] yaslar = new int[2];

            string[] personeller = new string[2];
            personeller[0] = "Azat";
            personeller[1] = "Ahmet";
            for (int pi = 0; pi < personeller.Length; pi++)
            {
                Console.WriteLine(personeller[pi]);
            }
            int[] yaslar2 = { 1, 2, 3, 4, };
            int[] yaslar3 = new int[] { 1, 2, 3, 4, }; //dikkat dizinin toplam kapsamı belirtilmedi.dizinin değer aralığı da belirtilebilirdi
            var yaslar4 = new[] { 1, 2, 3, 4 };

            #region Array Sınıfı
            // NOT: Referans türlü değişkenler: Sınıflardan türeyen nesneler
            //Dizi olarak tanımlanan değişkenler Array sınıfından türetilmektedir
            //Dolayısıyla dizilerde Array sınıfından gelen belirli metotlar ve özellikler mevcuttur
            int[] yaslar5 = new int[2];
            /*
             Dizi eğer ki kendi türünde referans ediliyorsa indexer operatörü kullanılabilir.Bu şekilde çalışıldığında ilgili diziye verisel müdahale operatif gerçekleşir
             Genellikle bu format algoritmalarda tercih edilir.Çünkü indexer algoritmalarda çok kullanılır
             */
            Array yaslar6 = new int[3];
            /*
             Array türünde referans ediliyorsa indexer op. kullanılmaz!
             yaslar6[0]=123; bunu yapamayız
             Bu şekilde ise fonksiyonel çözümler getirilmektedir.çağırırken fonksiyon çağırır gibi çağırırız
             */

            /*
               Array dizi = new int[] { 0, 1, 2, 3 };
              Array dizi = new int[2] { 0, 1 };
              Array dizi = new[] { 1, 2, 3 };
            Array sınıfından bu şekilde tanımlama yapılır.
             */
            Array dizi = new int[3];
            dizi.SetValue(20, 0);
            dizi.SetValue(21, 1); //Bunlar fonksiyonel işlemlerdir.0,1ve 2. indekslere şekildeki gibi atama yapıldı
            dizi.SetValue(22, 2);

            object value = dizi.GetValue(0);
            Console.WriteLine(value);

            #region Array Sınıfı Clear Metodu
            //Dizi içerisindeki tüm elemanları siliyor diye bilinir.Halbuki bu yanlıştır, dizi içerisindeki tüm elemanlara ,
            //dizinin türüne uygun default değerleri atayan bir fonksiyondur
            Array isimler = new[] { "A", "B", "C", "D" };
            Array.Clear(isimler, 0, isimler.Length);//isimler arrayinin 0. indexinden başlayarak isimler.length kadar elemanları default'a çevir

            #endregion
            #region Copy
            //Elimizdeki bir dizinin verilerini bir başka diziye kopyalamamızı sağlayan fonksiyondur
            string[] isimler2 = new string[isimler.Length];
            // Array.Copy(isimler, isimler2, isimler.Length); //isimler'den isimler2'ye bi kopyalama işlemi gerçekleşti . isimler.length kadar bir alan kopyalandı. DURUM1
            Array.Copy(isimler, 1, isimler2, 0, 2);//isimlerin 1. indexten kopyalamaya başla,isimler2'nin 0.indeksinden başlayarak kopyala ,isimler array'inin 2 elemanını al 
                                                   //bu çeşitli varyantları Array.Copy() yazdığımızda üzerinde kaynak bilgiden ne yapmamız gerektiğini öğrenebiliyoruz

            #endregion
            #region IndexOf
            /*
             Dizi içerisinde bir elemanın var olup olmadığını sorgulayabildiğimiz fonksiyondur
             Arama neticesinde ilgili değer varsa int olarak o değerin index numarasını döndürecektir
             yoksa -1 değerini döndürür
             */
            int index = Array.IndexOf(isimler, "A");
            if (index != -1)
            {
                //Demek ki aranan değer ilgili dizide bulunmaktadır
            }
            //farklı bir varyant 
            int index1 = Array.IndexOf(isimler, "A", 1, 3); //1-3. indexler arasında "A"değerini ara

            #endregion
            #region Reverse
            //Elimizdeki dizinin elemanlarını tersine sıralayan bir fonksiyondur
            Array.Reverse(isimler);
            Array.Reverse(isimler, 0, 3);//0.indexten başla toplam 3 tane tersine sırala

            #endregion
            #region Sort
            //sıralamayı sağlar. string'de alfabetik,int'te rakamsal
            Array.Sort(isimler);
            #endregion

            #region Özellikler
            #region IsReadOnly
            //Bir dizinin sadece okunabilir olup olmadığını bool türünde bildiren bir özelliktir
            //Console.WriteLine(isimler.IsReadOnly);
            #endregion
            #region IsFixedSize
            //Bir veri kümesinin eleman sayısının sabit olup olmama durumu IsFixedSize ile öğrenilebilir
            //Console.WriteLine(isimler.IsFixedSize);
            //Tüm dizilerde eleman sayısı sabit olduğundan sürekli true dönecektir.ArrayList koleksiyonu false dönecektir

            #endregion
            #region Length Özelliği
            //bir dizinin eleman sayısını verir
            #endregion
            #region Rank
            //Dizinin derecesini belirten özelliktir
            int[,,] rank = new int[2, 4, 5];
            Console.WriteLine(isimler.Rank);//1 dönecektir
            Console.WriteLine(rank.Rank);//3 dönecektir
            #endregion
            #region CreateInstance Metodu İle Dizi Tanımlama
            int[] array = new int[3];
            //Normalde yukardaki gibi yapılan dizi tanımlaması esasında arkaplanda Array sınıfının CreateInstance metodunu kullanmaktadır.
            //Bizler de bu metodu kullanarak fonksiyonel diziler oluşturabilmekteyiz
            Array array1 = Array.CreateInstance(typeof(int), 3);//3 elemanlı int türünde array oluşturuldu

            //CreateInstance Metodu İle Çok Boyutlu Dizi Tanımlama
            Array array2 = Array.CreateInstance(typeof(int), 4, 2, 4, 3); //4 boyutlu array oluşturuldu

            #endregion

            #endregion

            #endregion

            #endregion

            #region Ranges ve Indices Özelliği
            //System.Index
            /*,
             *Dizi ve koleksiyon yapılarındaki index kavramını tip olarak belirlenmiş halidir
             *Temelde index değerini bir tür ile tutmakla beraber ^ operatörüyle birlikte daha fazla anlam ifade etmekte ve dizinin index değerlerini tersine ifade edecek şekilde bir sorumluluk yüklenmektedir
             *index i=3;  0 1 2 3 
             *index i=^3; 3 2 1 dikkat 0 yok. Sağdan ve başlangıç değeri 1 ile numaralandırmaya başlar.
             *Indexer[]operatörü içerisine tam sayı verilebildiği gibi Index türüde verilebilir
             ör: sayilar[3], sayilar[sayi], sayilar[i]..
             *
             */
            int[] range = { 1, 2, 3, 4 };
            Index inde = ^2;
            // Console.WriteLine(inde); //Cevabı 3 verir . sağdan 2.index ,ama başlangıçta 0 yerine 1 verir

            //System.Range
            /*
             * Veri kümelerinde hangi değerler(değer aralığı) ile çalışacağımızı belirleyebilmek için index üzerinden aralık vermemizi ve bunu .. operatörü ile gerçekleştirmemizi sağlayan yapılanmadır.
             */
            string[] isler = { "A", "B", "C", "D", "E", "F", "G" };
            Range rang = 2..6; // 2=>Index No , 6=>Sıra No'yu temsil eder.Burda ise C-F aralığı işleme tabi tutulur
            Range rang2 = 3..^6; // Cevap D-A ^6 ifadesi ..'nın sağında olduğu için bi tane daha kaydıracak
            Range rang3 = ^2..^3; //Cevap F-D ^2 ifadesi ..'nın solunda olduğundan kayma olmayacak. ama ^3 ifadesi ..'nın sağında olduğundan bir tane daha kayacak
            /*
             * .. operatörü sağına ve soluna sayısal bir değer alabildiği gibi özü itibariyle Sytem.Index türünden de değerler alabilir
             * Geriye System.Range türünden yapı döndürür
             */
            int[] sayila = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Range ran = 5..8;
            var sayila2 = sayila[ran]; //6,7,8 değerlerini içerir
            Range ran1 = ..; //Tüm diziye karşılık gelir.
            var say = sayila[ran1]; //bu sayila dizisini olduğu gibi say'e kopyalar

            Range ran2 = 5..^3;
            var say1 = sayila[ran2];//6-7 aralığıdır.
            #endregion

            #region Çok Boyutlu Dizi Tanımlama
            int[,] cdizi = new int[2, 3]; //2 boyutlu dizi.x ve y koordinatlarını düşün
            /*
              Console.WriteLine(cdizi.Length); // cevap => 2*3=6
              Console.WriteLine(cdizi.GetLength(0)); // cevap=2 0.elemanın eleman sayısını verir
             */

            int[,,] cdizi2 = new int[1, 2, 4];//3 boyutlu dizi. 2'den büyük dereceye sahip dizileri günlük hayatta tahayyül etmek pek mümkün değildir
            cdizi[1, 2] = 5; //değer atama
            cdizi2[0, 2, 3] = 2; //3.derece diziye değer atama

            //FARKLI BİR VARYASYON
            int[,] cdizi3 =
            {
                {0,3,4 },
                {1,4,2 },
                {7,6,5 },
            };
            //  Console.WriteLine(cdizi[0, 1]);  > DEĞER okuma

            #region Dizzi İçerisinde Dizi Tanımlama/ Düzensiz Dizi
            /*
             Her bir elemanı kendi içerisinde farklı bir dizi barındıran dizilerdir
             Çok boyutlu dizilerden tek farklı , çok boyutlu dizilerin sütun sayılarının sabit, halbukim düzensiz dizilerin ise sütun sayılarının değişken olmasıdır
             */
            int[][] su = new int[2][];
            su[0] = new int[2] { 0, 1 };
            su[1] = new int[3] { 1, 3, 5 }; //görüldüğü gibi sütun uzunluğu birinde 2 diğerinde 3 olabiliyor
                                            //Düzensiz diziler çok kullanılan diziler değildir
                                            // Console.WriteLine(su[0][0]); // Cevap 0 döndürür
            /*
              Console.WriteLine(su.Length);  //Düzensiz dizinin eleman sayısını getirir. Bu bize total eleman sayısını vermez.Çok boyutlu dizilerde olduğu gibi düzensiz diziler başlı başına farklı bir dizi yapısı değildir. Normal dizi yapılanmasıdır. 
            Lakin içerisinde dizi barındıran bir dizidir. Haliyle eleman sayısını döndürür. 
            İçteki dizilerin eleman sayılarını totalde elde edebilmek için herbirini toplamamız gerekmektedir
              Console.WriteLine(su[0].Length + su[1].Length + su[2].Length); //Toplam değeri bu döndürür
             */

            #endregion

            #endregion

            #region String
            //string referans türlü olduğu halde programlama dilinde bir keyword barındıran tek değerdir.string referans türlü bir değişkendir
            #region Null-Empty Farkları
            #region Null
            /*
             Bir değişken/nullable/referans eğer ki null alıyorsa bu durum ilgili değişkenin herhangi bir alanı tahsis etmediği anlamına gelir. Arsa yok
             Değer türlü değişkenler null alamazlar 
             Null alabilen türler sadece referans türlerdir
             Değer türlü değişkenlerin null alabilmesi için nullabla(?)olmaları gerekmektedir
             int? a=null; string b=null;
             */
            #endregion
            #region Empty
            /*
             Bir değişkenim/nullable/referans eğer ki empty ise bu değişkenin değeri yok anlamına gelir.Lakin alan tahsisinde bulunmuştur. Arsa var lakin ev yok
             Tüm değerlere empty atanabilir.
             Alan tahsisinde bulunduktan sonra ilgili alana bir değer koymamak empy durumudur
             Default değerlerin olduğu durumlar empty olarak geçerler
             int a=0; , bool b=false; , int[] x=new int[3]; , 
             Empty dendiğinde  string b=""; değerinin verilmesi gelsin yeter.
             Null bellekte yer kaplamaz. Lakin empty her ne kadar değer almasada bellekte yer kaplayacak ve bir alan tahsisinde bulunmuş olacaktır
            string a="";  ya da string a2=string.Empty; /// empty
            string _a=null; ///null
             */
            //Null olan bir değer üzerinde işlem yapmaya çalışırsak run time hatası meydana gelir. Ama empty olan bir değer üzerinde işlem gerçekleştirilebilir.
            #endregion
            #region IsNullOrEmpty
            /*
              IsNullOrEmpty fonksiyonu,elimizdeki string ifadenin null yahut empty olup olmama durumları hakkında bir check yapar ve geriye bool türde sonuç döner
              değer null ya da empty ise true, değilse false dönecektir
              if(!string.IsNullOrEmpty(x)){}
             */
            #endregion
            #region IsNullOrWhiteSpace
            /*
              IsNullOrWhiteSpace fonksiyonu: elimizdeki string ifadenin null,empty yahut boşluk karakterlerinden ibaret olma durumunda geriye bool true değerini döndüren bir fonksiyondur
              string x="sdnc ";
             if(!string.IsNullOrWhiteSpace(x)){
            //Operasyon
            }
             */
            #endregion

            #endregion
            #region String RAM(Heap) İlişkisi
            /*
             string x="abc";
            string x => Stack kısmında depolanır
            "abc" => Heap kısmında depolanır
             */
            #endregion
            #region String-char Dizisi
            /*
             String ifadeler özündde bir char dizisi yani dizi olmasından dolayı referans türlü değişkenlerdir. Çünkü diziler referans türlüdürler.yani nesnedirler. yani heapte tutulurlar
            string metin="Azat";
            string ifadeler char dizisi olduklarından dolayı yapısal olarak her bir karakter baştan sona otomatik indexlenmektedir. Dolayısıyla string bir ifade üzerinde bizler indexer operatörünü de kullanabilmekteyiz
            Console.WriteLine(metin[0]); // A değerini döndürür
            Console.WriteLine(metin.Length);
            Array array=metin; //String özünde bir char dizisi olabilir ama yapısal olarak yine de string olduğu için Array referansına atılamaz, Array ile karşılanamaz!!
             */

            #endregion
            #region String Formatlandırma
            #region + Operatörü
            bool medenihal = true;
            int tcNo = 123; string name = "Azat";
            Console.WriteLine("" + (medenihal ? "Evli" : "Bekar")); // + ile formatlandırmada ternary(?) operatörü kullanılıyorsa bunu parantez içerisine alman gerekmektedir
                                                                    //   + ile formatlandırma hem kod hem de performans açısından 
            #endregion
            #region string.Format
            string.Format("Tc No: {0} olan {1} şahsın medeni hali : {2}", tcNo, name, medenihal ? "Evli" : "Bekar");
            //yukaradki değer string sonuc= strin.Format.... şeklinde string değere de atanabilirdi
            #endregion
            #region $(String Interpolation)
            Console.WriteLine($"TC No: {tcNo}, name: {name}, medeni hal: {(medenihal ? "Evli" : "Bekar")} {{Ahmet}}");
            //yukarda {{}} ifadesi ile string interpolation görevi iptal edildi ve çıktıya  {Ahmet} ifadesi yazılmış oldu
            #endregion

            #endregion

            #region @(Vebatim Strings) Operatörü

            #region 1.Kullanim
            /*
             Bir değişken yahut metot vs. gibi yapılanma isimlerinin programatik bir keyworde karşılık gelmesi mümkün değildir. Derleyici hatası verilir
             Eğer illa ben bir keyword ismi kullanıcam diyorsan @ kullanmalısın
             int @void=5;  ||  int @class=4;  || int @namespace=2;
             */
            #endregion
            #region 2.Kullanım
            /*
             Escape karakterlerinin kullanılması icap eden durumlarda @ operatörünü kullanarak eylemsel karakterleri kendileriyle ezebilecek özellik kazandırabiliyoruz.
             NORMAL: string metin= "hava çok \" güzel \" "; 
             @ İLE: string metin= @"hava çok ""güzel""  ";
             */
            #endregion
            #region 3.Kullanim
            /*
             string metin = "sömfdmd" +
                "södcbnsdkn " +
                "ösdncd";                //Normal Kullanım
            string metin2 = @"dsöfncdsc   
                             sdöncsnd    //@ ile Kullanım
                             sdömcnnmdc
                             ";  
             */
            #endregion
            /*
             $ ile @ operatörleri beraber kullanmamız gerkiyorsa önce @ sonra $ kullanılmalıdır
            string isim="azat"; , string soyisim="öner"; , int siparisNo=1;
            string mailMessage = @$"Merhaba {isim} {soyisim}
            {siparisNo} nolu siparişiniz...
            ";
             */
            #endregion

            #region String Fonksiyonları
            string metin = "merhaba Dünya";
            #region Contains
            /*
               bool sonuc = metin.Contains("me"); //Contains ifadenin varlığını sorgular
               Console.WriteLine(sonuc); 
             */
            #endregion
            #region StartsWith
            //  Console.WriteLine(metin.StartsWith("mer")); //true döndürecektir. mer ile başlıyor mu diye sorar
            #endregion
            #region EndsWith
            //Console.WriteLine(metin.EndsWith("ya")); //true dönnecektir. ya ile bitiyor
            #endregion
            #region Equals
            /*
             Elimizdeki metinsel ifade ile herhangi bir ifadenin değersel olarak eşit olup olmadığını check eden ve geriye bool sonuç dönen bir fonksiyondur
             Console.WriteLine(metin.Equals("merhaba Dünya")); //true dönecektir
             */
            #endregion
            #region Compare
            /*
             Metinsel ifadeleri karşılaştırmamızı ve sonuç olarak int türde elde etmemizi sağlar
             0:her iki değer birbirine eşittir.
             1:Soldaki sağdakinden alfanumerik olarak büyük
             -1:Soldaki sağdakinden alfanumerik olarak küçük

            Console.WriteLine(string.Compare(metin, "Z")); // Z m'den büyük olduğu için -1 döndürecek
            Console.WriteLine(string.Compare(metin, "a")); //1 döndürecek
            Console.WriteLine(string.Compare(metin, metin));//0 döndürecek
             */

            #endregion
            #region CompareTo
            /*
             Compare ile sadece şekilsel olarak farklılık gösterir.amaç aynıdır
             Console.WriteLine(metin.CompareTo("Z")); // Z m'den büyük olduğu için -1 döndürecek
             Console.WriteLine(metin.CompareTo("a")); //1 döndürecek
             Console.WriteLine(metin.CompareTo(metin));//0 döndürecek
             */
            #endregion
            #region IndexOf Metodu
            /*
             Verilen değerin string ifade içerisinde olup olmamasını geriye int olarak indexNo2yu döndüren bir fonksiyondur. yoksa -1 değerini döndürür.
            Console.WriteLine(metin.IndexOf("me")); //m 0.indexte olduğu için 0 döndürür
            Console.WriteLine(metin.IndexOf("mer"));//m 0.indexte olduğu için 0 döndürür
            Console.WriteLine(metin.IndexOf("Mer"));//M olmadığı için -1 döndürür
             */

            #endregion
            #region Insert
            //Elimizdeki metinsel ifadeye değer dahil etmemizi sağlayan bir fonksiyondur
            string eklenmisMetin = metin.Insert(7, "merhaba");

            #endregion
            #region Remove
            /*
             Metinsel ifadede indexel olarak verilen değer aralığını silen bir fonksiyondur.
             Insertte olduğu gibi ilgili fonksiyon yapmış olduğu işlem neticesinde yeni değeri üreterek bizlere string olarak döndürecektir. Elimizdeki orijinal veri değişmeyecektir
             Console.WriteLine(metin.Remove(5)); //5.indexten sonraki tüm değerleri sil
             Console.WriteLine(metin.Remove(5,10)); //5.indexten başla 10 adet sil

             */
            #endregion
            #region Replace
            /*
             Elimizdeki metinsel ifadede belirtilen değerleri yahut karakterleri,belirtilen diğer değerler ya da karakterler ile değiştirmemizi sağlayan bir fonksiyondur.
             Sonuç olarak string değer üretecek ve geriye döndürecektir
             Console.WriteLine(metin.Replace('a','b'));// a ve b harfleri yer değiştirir
             */
            #endregion
            #region Split
            /*
             Metinsel ifadeyi verilen değeri ayraç olarak kullanıp, parçalayan ve sonucu string dizisi olarak döndüren bir fonksiyondur
             string[]dizi=metin.Split(' ',"a"); // boşluk ve a gördüğü yerlerden metin'i keser . a yı ve boşluğu almaz diğerlerini parçalar. ör: merh, b , düny
             */
            #endregion

            #region Substring
            /*
             String fonksiyonları arasında en önemlisidir
             Metinsel ifadenin belirli bir aralığını elde etmemizi sağlar
             Console.WriteLine(metin.Substring(5)); 5.indexten sonuna kadar tüm değerleri getirir
             Console.WriteLine(metin.Substring(5,3)); 5.indexten başlayacak 3 karakter getirecek
             */
            #endregion
            #region TOLower-TOUpper
            /*
          TOLower: Eldeki metinsel ifadenin tüm karakterlerini küçük karakter olarak düzenler
          TOLower: Eldeki metinsel ifadenin tüm karakterlerini BÜYÜK karakter olarak düzenler  
          Console.WriteLine(metin.TOLower); gibi..
             */
            #endregion
            #region Trim
            /*
             Metinsel ifadelerin varsa solundaki ve sağındaki boşluk karakterleri temizleyen bir fonksiyondur
             Console.WriteLine("ahmet cümbül");
             Console.WriteLine("     ahmet cümbül      ".Trim()); //Çıktı yukardakiyle aynı    
             */

            #endregion

            #region TrimEnd
            //verilen ifadenin sağındaki boşluğu silecektir
            #endregion
            #region TrimStart
            //verilen ifadenin başındaki boşlukları siler
            #endregion

            #region  STRING ÖRNEK
            /*
              string adSoyad = "Azat Öner";
              Adımızın ilkten 3. soyadımızın sondan 5.karakterini getirelim
              string aralik = adSoyad[2..^5];
              Console.WriteLine(aralik[0]);  // a
              Console.WriteLine(aralik[aralik.Length-1]);  // soyisim bukadar uzun 
               */
            #endregion

            #region Girilen Metindeki Kelime Sayısını Hesaplayalım
            /*
              Console.WriteLine("Lütfen bir metin giriniz");
            string metin1 = Console.ReadLine();
            int adet = 1;
            while (true)
            {
                int index0 = metin1.IndexOf(' ');
                if (index == -1)
                    break;

                adet++;
                metin1=metin1.Substring(index0+1);
            }
            Console.WriteLine(adet);
             */
            #endregion

            #endregion

            #region Dizilerde Verisel Performans
            int[] sayilar0 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            #region ArraySegment Nedir?
            /*
             Bir dizinin bütününden ziyade belirli bir kısmına yahut parçasına ihtiyaç dahilinde ilgili diziyi kopyalamak yerine(ki görece oldukça maaliyetli bir operasyondur)
             bağımsız bir referans ile erişmemizi ve böylece salt bir şekilde temsil etmemizi sağlayan bir yapıdır
             */
            #endregion
            #region ArraySegment İle Dizinin Belli Bir Alanını Referans Etmek
            /*
             ArraySegment<int> segment1 = new ArraySegment<int>(sayilar0); //Dizinin tüm elemanlarını temsil eder
            ArraySegment<int> segment2 = new ArraySegment<int>(sayilar0,2,5);//2.indeksten başlayıp 5.sayıya kadar

            segment1[0] *= 10; //Bu değişiklikten sonra sayilar0'ın da ilk değeri 10 oldu
            segment2[0] *= 10; //Bu değişiklikten sonra sayilar0'ın da 2.indeksi 30 oldu.Çünkü ArraySegment temsil ediyordu
             */
            #endregion
            #region ArraySegment Silicing(Dilimleme)
            /*
             Bir dizi üzerinde birden fazla parçada çalışacaksan eğer herbir parçayı ayrı bir ArraySegment olarak tanımlayabiliriz. Bu tanımlamaların dışında diziyi tek bir arraysegment ile referans edip ilgili parçaları o segment üzerinden talep edebiliriz.Yani ilgili diziyi
            tek bir segment üzerinden daha rahat bir şekilde parçalayabiliriz.Bu durumda bize yazılımsal açıdan efektiflik kazandırmış olacaktır
            ArraySegment<int> segment = new ArraySegment<int>(sayilar0);
            ArraySegment<int> segment1 = segment.Slice(0, 3);
            ArraySegment<int> segment2 = segment.Slice(4, 7);
             */


            #endregion

            #region StringSegment Nedir?
            /*
             StringSegment, ArraySegment'in string değerler nezdindeki bir muadilidir
             Esasında metinsel değerlerdeki birçok analitik operasyonlardan bizleri kurtarmakta ve Substring vs. gibi fonksiyonlar yerine string değerde hedef kesit üzerinde işlem yapmamızı sağlayan bir türdür.
             */

            #endregion
            #region StringSegment İle Dizinin Belli Bir Alanını Referans Etmek
            string text = "Ölüme gidelim dedin de mazot mu yok dedik.";

            /*
             StringSegment türünü kullanabilmemiz için uygulamaya Microsoft.Extensions.Privates paketinin yüklenmesi gerekmektedir
              StringSegment yazdıktan sonra ampule tıklayarak ilgili paketi yükleyebilirsin
            
            StringSegment segment= new StringSegment(text); //text gibi bir referans segment'e belirlendi
            StringSegment segment1 = new StringSegment(text,2,5); //SubString'e göre performans açısından ÇOK DAHA FAZLA AVANTAJLI
            Console.WriteLine(segment1); //StringSegment geriye string döndürdüğünden direkt yazdırabiliriz
             */

            #endregion

            #region StringBuilder Sınıfı
            string nav = "Azat";
            string pesnav = "Öner";
            /*
             Console.WritLİne(isim+ " " + soyisim);
            StringBuilder, string birleştirme operasyonlarında + operatörüne nazaran yüksek maliyeti absorbe edebilmek için
            arkaplanda StringSegment algoritmasını kullanan ve bu algoritma ile bizlere ilgili değerleri
            olabilecek en az maliyetle birleştirip döndüren bir Sınıftır
           
            StringBuilder builder= new StringBuilder();
            builder.Append(nav);
            builder.Append(" ");
            builder.Append(pesnav); 
          Console.WriteLine(builder.ToString())  //yapılan bu işlem Console.WritLİne(isim+ " " + soyisim); budur ama daha az maaliyetli
             */
            #endregion
            #region Span
            /*
             Spanı ArraySegment ve StringSegment gibi düşünebilirsin. maaliyet azlığı***
             Span<int>span = new Span<int>(sayilar0);
            Span<int> span1 = sayilar0;
            Span<int> span2 = new Span<int>(sayilar0,2,5);
             
             */


            #endregion
            #endregion

            #endregion

            #region Koleksiyonlar 
            #region ArrayList
            #region ArrayList Koleksiyon Tanımlama
            ArrayList _yaslar = new ArrayList(); //kapasitesi bildirilmek zorunda değil****,

            #endregion
            #region Tanımlanmış Koleksiyona Değer Atama
            for (int ti = 0; ti < 17; ti++)
            {
                _yaslar.Add(ti + 10);//ArrayList tanımlanırken içine alacağı tür object'tir.yani boxing işlemi yapılmış olur.
            }
            #endregion
            #region Tanımlanmış Koleksiyondan Değer Okuma
            //  Console.WriteLine(_yaslar[5]) //Değer okuma işlemi dizilerdeki gibi olur
            #endregion
            #region ArrayList Kullanılırken Boxing-Unboxing Durumları
            /*
             ArrayList, verilen datayı boxing işlemine tabi tutar
             ArrayList içerisindeki herhangi bir veriyi talep ettiğimizde o veri object olarak gelecektir.Dolayısıyla kendi türünde işlem yapabilmek için unboxing işlemine tabi tutmamız gerekir
             */
            int topla = 0;
            for (int il = 0; il < 17; il++)
            {
                topla += (int)_yaslar[i]; //burda (int) ile Unboxing işlemine tabi tuttuk. o şekilde işleme girdi
            }

            #endregion
            #region ArrayList Collection Initializers(Koleksiyon İlklendirici)İle değer Ekleme
            ArrayList arrayList = new ArrayList()
            {
                "Azat",
                12,
                'a',
            };
            #endregion

            #endregion

            #endregion

            #region İterasyon vs Döngü
            /*
             Mantıksal açıdan her tahminin altında bir iterasyon mantığı yatar.
             Foreach(İterasyon) bir DÖNGÜ DEĞİLDİR
             Foreach çalışması için bir veri kümesine muhtaçtır
             Foreach verilen dizinin, koleksiyonun eleman sayısına bağlıdır.tabir caizse sonsuz bir döngüye giremez
             */
            ArrayList sayilar = new ArrayList { 1, 2, 3, 4, 5, 6, 7 };
            foreach (object item in sayilar)
            {
                // sayilar.Add(12453173); //koleksiyona yeni bir eleman eklendi , foreach için bir problem oluşur.foreach verilen koleksiyona odaklanır değişikliiklerde problem olur
                //    Console.WriteLine(item); //Koleksiyonun tüm elemanlarını getirir
            }

            #endregion

            #region Hazır Sınıflar

            #region Math Sınıfı
            #region Abs
            /*
             Mutlak değer
             Absolute Value
             int i= Math.Abs(-5); //5 döndürdü
             */
            #endregion
            #region Ceiling
            /*
             Console.WriteLine(Math.Ceiling(3.14));// 4'e yuvarlar 
             */
            #endregion
            #region Floor
            /*
               Console.WriteLine(Math.Floor(3.14));// 3'e yuvarlar 
             */
            #endregion
            #region Round
            /* En yakın tamsayıya yuvarlar
              Console.WriteLine(Math.Round(3.14));// 3'e yuvarlar 
              3.5=>4'e yuvarlar
              3.6=>4'e yuvarlar
            */
            #endregion
            #region Pow
            /* En yakın tamsayıya yuvarlar
              Console.WriteLine(Math.Pow(2.3));//double türde 8 döndürür
            */
            #endregion
            #region Sqrt
            /* Karekökünü alır
             Console.WriteLine(Math.Sqrt(4));// 2 
           */
            #endregion
            #region Truncate
            /*
             Verilen ifadenin sadece tam kısmını alır
             Console.WriteLine(Math.Truncate(2.6));// 2 
             */
            #endregion

            #endregion

            #region DateTime Struct'ı

            #region Now
            /*
             Console.WriteLine(DateTime.Now); //şimdiki zamanı döndürür
             */
            #endregion
            #region Today
            /*
           Console.WriteLine(DateTime.Today); //sadece o anki tarihi yani gün bilgisine kadar getirir.Now saniyesine kadar getirir
           */
            #endregion
            #region Compare
            /*
            DateTime tarih1 = new DateTime(2021, 01, 01);
            DateTime tarih2 = new DateTime(2022, 01, 01);
            int result=DateTime.Compare(tarih1, tarih2);
            result=-1 tarih1<tarih2
            result=0 tarih1=tarih2
            result=1 tarih1>tarih2 dir.
             */
            #endregion
            #region AddDays-AddHours-AddMonths-AddYears-AddMilliseconds 
            //  Console.WriteLine(DateTime.Now.AddYears(2)); //2 yıl sonrasını gösterecektir
            #endregion
            #region TimeSpan Struct'ı
            /*
             Zamanlar arasındaki farkı belirtir
             DateTime t1 = DateTime.Now;
             DateTime t0 = new DateTime(2000,1,1);
             TimeSpan span = t1 - t0;
             Console.WriteLine(span.Days);
             */
            #endregion
            #region Random Sınıfı
            Random random = new Random();
            #region Next Fonksiyonu
            /*
            Console.WriteLine(random.Next());
            Console.WriteLine(random.Next(100)); //0-100
            Console.WriteLine(random.Next(50,100)); //50-100
             */
            #endregion
            #region NextDouble Fonksiyonu
            // Console.WriteLine(random.NextDouble()); //0-1 arasında sayı üretir
            #endregion
            #endregion

            #endregion


            #endregion
            #region Metotlar
            /*
              Geriye dönüş değeri, kodun içerisinde yakalanabilir ve programatik olarak işlemlere tabi tutulabilir.Geri dönüş değerini ekran çıktısı ile karıştırmamamız gerekir
               [erisim belirleyicisi][geri dönüş değeri][metodun adi] () //Bu kısım İMZA kısmıdır
                {
                //Bu kısım GÖVDE kısmıdır
                }

            static private void Main(string[] arg) //private erisim belirleyici
            { 
             }
             */

            //DEVAMI AŞAĞIDA CLASS SCOPE'U ALTINDA
            #endregion
            #region Metodun Geriye Değer Döndürmesi Ne Demektir?
            Topla(3, 5); //Topla metodunu kullanabilmem için Topla metodunun bu metod gibi static değer olması gerek, yoksa kullanamazsız
            /*
             Metodun değer döndürmesi yaptığı işlemler sonucunda ekrana/consola/veri tabanına bir çıktı vermesi demek DEĞİLDİR
             Metodun geriye döndürdüğü değer algoritmanın akışında kullanılabilir değerdir.
             */
            bool sonuc3 = PersonelEkleme("Azat", 23);

            #endregion
            #region Optional Parameters(İsteğe Bağlı Parametreler)
            /*
             Eğer ki bir metodun parametrelerine zorunlu bir şekilde değer göndermek istemiyorsak,parametreye değeri isteğimize göre/opsiyonel göndermek istiyorsak o parametrenin
             bu durumu karşılayabilecek bir özellikte olması gerekir bu özelliğe opsiyonel parametre denir
             Bir parametrenin opsiyonel olması demek o parametrenin varsayılan/default değeri olması demektir
             metoddaki parametrelere değer atanırsa o parametre varsayılan değeri atamıştır demektir. opsiyonel parametre haline getirilmiş olur
             Birden fazla parametre durumunda opsiyonel olanlar sağda TANIMLANMALIDIR

             */
            X9(2, 7);// X9(2); şeklinde de tanımlamalar yapılabilirdi
            #endregion

            #region Referans ve Nesne İlişkisi
            /*
             Nesne= Class'tan üretilen değer,veri.
             Referans=Class'tan üretilen değeri kullanmamızı sağlayan yapı.
             A a (sol taraf: referans) =new A(); (sağ taraf object) 
             */
            #endregion

            #region Başka Sınıfta Tanımlanmış Bir Metodun Kullanımı
            Matematik matematik = new Matematik();
            //   Console.WriteLine(matematik.Topla(3,5)); //8 döndürür
            #endregion
            #region Non-Trailing Named Arguments 
            /*
             Hangi parametreye hangi değerleri gönderildiğini direkt görebilmek için bu özelliği kullanırız
             Bununla beraber fonksiyonda verilen sıraya göre değil de istediğimiz sıraya göre değerleri verebiliyoruz
             */
            X8(3, 5, "abc");
            X8(z: "acb", x: 1, y: 2); // Bu non-trailing'dir
            #endregion
            #region In Parameters
            /*
             Parametrenin değerini metodun içerisinde herhangi bir yerde çağırıp kullanabiliriz
             Metot içerisinde üretilen herhangi bir değeri tutacak değişken oluşturmaktansa parametre üzerinde bu değeri tutabiliriz
            Yani parametrenin değerini değiştirebiliriz.(çünkü parametreler özünde bir değişkendir)
             In komutu sayesinde parametreye verilen değeri sabit tutabilmekteyiz
             In komutu, metodun parametresini readonly(sadece okunabilir)hale getirir
             In komununun kullanıldığı parametrelerde eğer ki metot içerisinde farklı bir assign söz konusu olursa derleyici hata verir.
             */
            #endregion
            #region Local Function
            /*
             Bir metod içerisinde tanımlanmış metodlardır!
             Metodlar, OOP'de göreceğimiz struct,abstract class, interface, record yapılanmalarında da metodlar tanımlanmaktadır. Metodlar bu saydıklarımızın dışında KESİNLİKLE tanımlanamaz
             Metodlar, local function özelliği ile metod içerisinde tanımlanabilmektedirler

             */
            #region Tanımlama Kuralları
            /*
             Erişim belirleyici(private/public) yazılmaz
             Local function olarak tanımlanan fonksiyon adı tanımlandığı fonksiyonun adından farklı olmalıdır!Aksi takdirde derleyici hatası VERMEZ!!!
             */
            #endregion
            #region Kullanım Kuralları
            /*
             -Bir local function sade ve sadece tanımlandığı metodun içerisinde kullanılabilir
             -Local function tanımlandığı metodun içerisinde her yerden erişilebilir
             */
            #endregion
            #region Amacı 
            /*
             Local function, sadece tek bir metodda tekrarlı bir şekilde kullanılacak bir algoritmayı/kod parçacığını/işlemi o metoda özel bir şekilde tek seferlik tanımlamamızı ve kullanmamızı sağlamaktadır   
             */
            #endregion
            #region Muadilleri
            //Anonim,Delegate,Function
            #endregion
            #region staticLocalfunction
            static void slocalFunction()
            {
                /*local function'a göre daha az maaliyetli ve daha performanslıdır
                 * normalde local func. içinde bulunduğu üst fonksiyonun parametrelerine erişebilirken static local func. erişemez
                 */
            }
            #endregion

            #endregion

            #region Metodlarda Overloading(Çoklu Yükleme)
            /*
             Bir class içerisinde belirli kurallar çerçevesinde aynı isimde birden fazla metot oluşturmaya Method Overloading denir
             */
            #region Overloading Kuralları
            /*
             Bir sınıf içerisinde birden fazla aynı isimde metot tanımlayabilmek için şu kurallara dikkat etmek gerek
             Metod Overloading işlemini yapabilmek için metodların isimleri aynı olmalıdır
             Bu metodlar içinde fark oluşturmamız gerekmektedir
             Bu fark bizzat imzalarında olmalıdır
             Metodlar arasındaki fark ; erişim belirleyicileri ve gerş dönüş değerleri aktif rol oynamamaktadır
             *Parametre sayıları ya da parametre türleri farklı olmalıdır!*
             */
            #endregion
            #endregion
        }

        #region Metotlar Devam

        #region Geriye Değer Döndürmeyen, Parametre Almayan Metot
        private void Metot1()
        {
            //gövde kısmı
        }
        #endregion
        #region Geriye Değer Döndürmeyen, Parametre Alan Metot
        public void Metot2(int a, bool b, char c)
        {

        }
        #endregion
        #region Geriye Değer Döndüren, Parametre Almayan Metot
        private char Metot3() //private yazılmazsa da tür otomatik private atanır
        {
            /*
                Bir metod geriye değer döndğreceğini söylerse , kesinlikle geri değer döndürmelidir yoksa hata alınır
                Return nerde tetiklenirse ordan fonksiyondan çıkılır
             */
            return 'a';
        }
        #endregion
        #region Geriye Değer Döndüren, Parametre Alan Metot
        public bool Metot4(int x)
        {
            return true;
        }
        #endregion

        static public int Topla(int sayi1, int sayi2)
        {
            int sonuc = sayi1 + sayi2;
            return sonuc; ;
        }
        static public bool PersonelEkleme(string isim, int yas)
        {
            if (yas >= 20)
            {
                //işlem başarılı 
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
        static public void X9(int a, int b = 2) //burda b opsiyonel parametredir
        {

        }
        static public void X8(int x, int y, string z)
        {

        }
        static public void In(in int x, int y)
        {
            //x = 3; //hata verecektir çünkü in ile işaretlendiğinden değeri değiştirilemez
            y = 5;
        }

        public static void localFunction()
        {
            void local2()
            {

            }
        }
    }

    class Matematik
    {
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

    }

    class Overloading
    {
        public static void overloading(int sayi1, int sayi2)
        {

        }
        public static void overloading(int sayi1, int sayi2, int sayi3)
        {

        }
        public static void overloading(int sayi1, int sayi2, string ifade)
        {

        }
    }


    class Reqursive
    {

        #region RECURSIVE FONK.
        /*
         Kendi içerisinde kendisini çağıran/tetikleyen fonksiyonlardır
         Özyinelemeli/Tekrarlamalı Fonk.
         Reqursive fonk. bir yaklaşımdır!.
         Anlaşılması,kullanılması ve anlatması zordur
          Reqursive fonk.ne amaçla kullanılmaktadır? 
         Öngörülemeyen, derinliği tahmin edilemeyen, sonu bilinmeyen durumlarda tercih edilebilir. 
        Fonksiyon kendi içinde kendisini çağırıyorsa bu reqursive fonk. olur
        Döngülerin kullanıldığı her noktada reqursive fonk. kullanılabilir. Ama rec. fonk. kullanıldığı her yerde döngü KULLANILAMAZ!!!
         */
        void Reqursiv(int a = 1) //Reqursive burda kontrol altına alındı
        {
            Console.WriteLine("merhaba");
            if (a < 3)
            {
                Reqursiv(++a);
            }
        }

        #region Reqursive Örnek 1
        //belirli değer aralığında 5in katı olan tüm sayıları toplayan rec. fonk. yazalım
        int Topla(int baslangic, int bitis)
        {
            if (baslangic % 5 == 0)
            {
                return baslangic + Topla(++baslangic, bitis);
            }
            if (baslangic < bitis)
            {
                return Topla(++baslangic, bitis);
            }

            return 0;
        }
        #endregion

        #endregion
    }

    class RefKeyword
    {
        /*
         İki referans birbirine eşitlenirse(r2=r;) (=)'işareti artık assign operatörü değildir.referans etme operatörüdür
         Referans HEAP'teki objeyi erişilebilir kılar. referans STACK'da bulunur
         ref keyword'ü, referanstan gelmektedir
         Referans, OOP kavramıdır
         OOP'de nesneler(object) RAM'de Heap bölgesinde tutulmaktadır
         OOP'de referanslar  = operatörüyle iletişime geçebilmektedirler. Bir referans, işaretlediği herhangi bir nesneyi = operatörü sayesinde farklı bir referansa işaretletebilir
         Yani, referanslar = operatörü neticesinde herhangi bir verisel/nesnesel türeme söz konusu olmamakta, işaretlenmiş nesne diğer referans tarafından işaretlenmektedir

      int a=5; int b=a; //buna DEEP COPY diyorduk
      ref int b= ref a; //bu da ref etme . a'nın referansı gelir b'ye gider   
      yukardaki işlemde a ve b aynı kaynaktan besleniyor demektir, herhangi birini değiştirdiğimizde her ikisi de değişir
       
      Değer türlü değişkenlerde referans çalışması yapmak istiyorsak eğer ref keywordü kullanılır
      ref keywordü, değer türlü değişkenlerin referans türlü değişkenler gibi çalışmasını sağlayan bir komuttur.
      Değer türlü değişkenlerde shallow copy(yüzeysel kopyalama=yeni bir değer oluşturma değil) yapmamızı sağlayan bir keyworddür.
        
      ref HEAP'teki değil, STACK'deki Değer türlü değişkenleri referans etmemizi sağlayan keyworddür
         */
        #region Örnek 1

        /*
        int a = 5;
        ref int b = ref a;


        a*=5;
        Console.WriteLine(b); //25
        
        b-=10;
        Console.WriteLine(a); //15
         */

        #endregion
        #region Örnek 2

        /*
           int y = 10;
          X(ref y); burda ******   ref y = ref int a; işlemi gerçekleşmiş oldu
         Console.WriteLine(y); //bundan dolayı çıktı 25 olur . normal değer türlü değişken olmuş olsalardı yani ref olmasalardı 10 çıkardı
          void X(ref int a)
          {
              a = 25;
          }
         */

        #endregion

        #region Ref Returns
        /*
         ref returns özelliği sadece metodlarda geçerlidir
         Metotlar geriye değer döndürebilen yapılardır. Ayrıca metotlarda geriye nesneler de döndürebiliriz
         */
        #region Örnek 1 

        /*
        int a = 5;
        int b = X(ref a);
        Console.WriteLine(a);
        Console.WriteLine(b);

        ref int X(ref int y)
        {
            y = 25;
            return ref y;
        }
         */

        #endregion

        #endregion

    }

    class OutKeyword
    {
        #region Out Keyword
        /*
         Bir metodun parametreleri varsayılan olarak INPUT'tur. Haliyle metodlarda tanımlanmış parametreler direkt olarak içeriye değer almaya odaklanırlar..
         Eğer ki bir metodun parametresi dışarıya değer çıkaracaksa o parametrenin out keywordüyle işaretlenmesi gerekir
         Output parametre barındıran bir metodu kullanırken, out parametrelerden gelecek olan değerleri karşılayacak değişkenler tanımlanmalıdır!!

        int a = X(out int _b, 123 , out string _d);
        Console.WriteLine(_b); //25 
        Console.WriteLine(_d); //ahmet

        int X(out int b,int c, out string d)
        {
            //Bir metod (parametreler) barındırıyorsa o parametrelere kendi içerisinde değer atanması gerekmektedir! Aksi taktirde derleyici hata alınacaktır
            b = 25; //out değer olduğu için metod içinde değer verilmeli
            d = "ahmet";
            return 0;
        }

         */


        #endregion
    }

    class TryParse
    {
        /*
          string a = "123";
            if(int.TryParse(a,out int r) )
                {

                }
            else
            {

            } 
         */
    }

}



