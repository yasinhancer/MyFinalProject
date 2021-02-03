using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Abstract;

namespace DataAccess.Abstract
{
    //birden çok farklı interface'de bunları kullandığım için, bunları burada bir kez yazıyorum, 
    //tipini de T veriyorum ki burayı implemente ettiğim yerde ben ne tipte istersem o tipte çalışabileyim 
    
    //generic constraint : generic kısıt >>> T yerine girilebilecek değerleri kısıtlama
    //new() : newlenebilir olmalı (abstract type olamaz)
    public interface IEntityRepository<T> where T: class,IEntity,new() //class: referans tip olabilir demek
                                                                 //sonrasında gelen IEntity sayesinde,
                                                                 //T yerine IEntity girilebilir,
                                                                 //ya da IEntity'i implemente edenler
                                                                 //girilebilir,
                                                                 //new() sayesinde de newlenebilen,
                                                                 //yani sadece somut nesneler olmalı dedim
                                                                 //ve sonucunda T yerine sadece
                                                                 //IEntity'i implemente eden somut nesneler gelebilecek.
    {
        //aşağıdaki kodu, ilk metota bir filtre ekleyip, getirme işlemini daraltabilmek için ekledim.
        //yani bu sayede, tek kod sayesinde hem tüm datayı, hem de istersem;
        //istediğim şekilde filtreleyip istediğim datayı getirtebilirim...
        List<T> GetAll(Expression<Func<T,bool>> filter = null); 
        //filtre girmediğimde tüm datayı getirsin diye filter'ın default değerini null verdim. 
        T Get(Expression<Func<T, bool>> filter); //T döndüren get operasyonu
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
