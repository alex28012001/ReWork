﻿using ReWork.DataProvider.Repositories.Abstraction;
using ReWork.Model.Entities;
using ReWork.Model.EntitiesInfo;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ReWork.DataProvider.Repositories.Implementation
{
    public class FeedBackRepository : BaseRepository, IFeedBackRepository
    {
        public void Create(FeedBack item)
        {
            Db.FeedBacks.Add(item);
        }

        public void Delete(FeedBack item)
        {
            Db.FeedBacks.Remove(item);
        }

        public IEnumerable<FeedBackInfo> FindRecivedFeedBacks(string reciverId)
        {
            return (from f in Db.FeedBacks
                    join j in Db.Jobs on f.JobId equals j.Id
                    join s in Db.Users on f.SenderId equals s.Id
                    orderby f.AddedDate descending
                    where f.ReceiverId == reciverId
                    select new FeedBackInfo()
                    {
                        Text = f.Text,
                        AddedDate = f.AddedDate,
                        QualityOfWork = f.QualityOfWork,

                        SenderId = s.Id,
                        SenderName = s.UserName,
                        SenderImage = s.Image,

                        JobId = j.Id,
                        JobTitle = j.Title
                    }).ToList();
        }

        public IEnumerable<FeedBackInfo> FindSentFeedBacks(string senderId)
        {
            return (from f in Db.FeedBacks
                    join j in Db.Jobs on f.JobId equals j.Id
                    join s in Db.Users on f.SenderId equals s.Id
                    orderby f.AddedDate descending
                    where f.SenderId == senderId
                    select new FeedBackInfo()
                    {
                        Text = f.Text,
                        AddedDate = f.AddedDate,
                        QualityOfWork = f.QualityOfWork,

                        SenderId = s.Id,
                        SenderName = s.UserName,
                        SenderImage = s.Image,

                        JobId = j.Id,
                        JobTitle = j.Title
                    }).ToList();
        }

        public void Update(FeedBack item)
        {
            Db.Entry(item).State = EntityState.Modified;
        }
    }
}
