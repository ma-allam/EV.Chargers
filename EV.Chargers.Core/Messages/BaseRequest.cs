﻿namespace EV.Chargers.Core.Messages
{
    public abstract class BaseRequest : BaseMessage
    {
        public BaseRequest(Guid correlationId) : base()
        {
            _correlationId = correlationId;
        }

        public BaseRequest()
        {
        }
    }
}
