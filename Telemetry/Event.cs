using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace Telemetry
{
    public abstract class Event
    {
        public int id_user;
        public int id_session;
        public long send_time;

        public Event(int user, int session)
        {
            id_user = user;
            id_session = session;
            send_time = DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        public string ToCSV()
        {
            string s = "Send Time, " + send_time + "Session Id, " + id_session + "Session User, " + id_user;
            return s;
        }
    }

    // EVENTOS GENERALES =======================================================================
    public class StartSession : Event
    {
        public StartSession(int user, int session) : base(user, session)
        {
        }
        public string ToCSV()
        {
            Type type = typeof(StartSession);
            string s = "Type Event," + type.Name + " " + base.ToCSV();
            return s;
        }
    }

    public class EndSession : Event
    {
        public EndSession(int user, int session) : base(user, session)
        {
        }
        public string ToCSV()
        {
            Type type = typeof(EndSession);
            string s = "Type Event," + type.Name + " " + base.ToCSV();
            return s;
        }
    }

    public class StartGame : Event
    {
        int id_game;
        public StartGame(int user, int session, int game) : base(user, session)
        {
            id_game = game;
        }
        public string ToCSV()
        {
            Type type = typeof(StartGame);
            string s = "Type Event, " + type.Name + " " + base.ToCSV() + " Game Id, " + id_game;
            return s;
        }
    }

    public class EndGame : Event
    {
        int id_game;
        public EndGame(int user, int session, int game) : base(user, session)
        {
            id_game = game;
        }
        public string ToCSV()
        {
            Type type = typeof(EndGame);
            string s = "Type Event, " + type.Name + " " + base.ToCSV() + " Game Id, " + id_game;
            return s;
        }
    }

    public class GameAborted : Event
    {
        int id_game;
        public GameAborted(int user, int session, int game) : base(user, session)
        {
            id_game = game;
        }
        public string ToCSV()
        {
            Type type = typeof(GameAborted);
            string s = "Type Event, " + type.Name + " " + base.ToCSV() + " Game Id, " + id_game;
            return s;
        }
    }

    // EVENTOS "CABLEADOS" DE GETHIGH =======================================================================

    // OBJETIVO 1
    public class TimeStart : Event
    {
        int id_game;
        int id_quest;
        int id_setQuest;

        public TimeStart(int user, int session, int game, int question, int questionSet) : base(user, session)
        {
            id_game = game;
            id_quest = question;
            id_setQuest = questionSet;
        }
        public string ToCSV()
        {
            Type type = typeof(TimeStart);
            string s = "Type Event, " + type.Name + " " + base.ToCSV() + " Game Id, " + id_game + ". \n Question Id, " + id_quest + " Question Set Id, " + id_setQuest;
            return s;
        }
    }

    public class TimeReply : Event
    {
        int id_game;
        int id_quest;
        int id_setQuest;
        bool correct;

        public TimeReply(int user, int session, int game, int question, int questionSet, bool result) : base(user, session)
        {
            id_game = game;
            id_quest = question;
            id_setQuest = questionSet;
            correct = result;
        }
        public string ToCSV()
        {
            Type type = typeof(TimeReply);
            string s = "Type Event, " + type.Name + " " + base.ToCSV() + " Game Id, " + id_game + ". \n Question Id, " + id_quest + " Question Set Id, " + id_setQuest + " Correct, " + correct;
            return s;
        }
    }

    // OBJETIVO 2
    public class GetBlock : Event
    {
        int id_game;
        int id_block;

        public GetBlock(int user, int session, int game, int block) : base(user, session)
        {
            id_game = game;
            id_block = block;
        }
        public string ToCSV()
        {
            Type type = typeof(GetBlock);
            string s = "Type Event, " + type.Name + " " + base.ToCSV() + " Game Id, " + id_game + ". \n Block Id, " + id_block;
            return s;
        }
    }

    public class GrabBlock : Event
    {
        int id_game;
        int id_block;

        public GrabBlock(int user, int session, int game, int block) : base(user, session)
        {
            id_game = game;
            id_block = block;
        }
        public string ToCSV()
        {
            Type type = typeof(GrabBlock);
            string s = "Type Event, " + type.Name + " " + base.ToCSV() + " Game Id, " + id_game + ". \n Block Id, " + id_block;
            return s;
        }
    }

    public class ReleaseBlock : Event
    {
        int id_game;
        int id_block;

        public ReleaseBlock(int user, int session, int game, int block) : base(user, session)
        {
            id_game = game;
            id_block = block;
        }
        public string ToCSV()
        {
            Type type = typeof(ReleaseBlock);
            string s = "Type Event, " + type.Name + " " + base.ToCSV() + " Game Id, " + id_game + ". \n Block Id, " + id_block;
            return s;
        }
    }
}
