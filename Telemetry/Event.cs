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
        public int id_user { get; set; }
        public int id_session { get; set; }
        public long send_time { get; set; }

        public Event(int user, int session)
        {
            id_user = user;
            id_session = session;
            send_time = DateTimeOffset.Now.ToUnixTimeSeconds();
        }
    }

    // EVENTOS GENERALES =======================================================================
    public class StartSession : Event
    {
        public StartSession(int user, int session) : base(user, session)
        {
        }
    }

    public class EndSession : Event
    {
        public EndSession(int user, int session) : base(user, session)
        {
        }
    }

    public class StartGame : Event
    {
        int id_game { get; set; }
        public StartGame(int user, int session, int game) : base(user, session)
        {
            id_game = game;
        }
    }

    public class EndGame : Event
    {
        int id_game { get; set; }
        public EndGame(int user, int session, int game) : base(user, session)
        {
            id_game = game;
        }
    }

    public class GameAborted : Event
    {
        int id_game { get; set; }
        public GameAborted(int user, int session, int game) : base(user, session)
        {
            id_game = game;
        }
    }

    // EVENTOS "CABLEADOS" DE GETHIGH =======================================================================

    // OBJETIVO 1
    public class TimeStart : Event
    {
        int id_game { get; set; }
        int id_quest { get; set; }
        int id_setQuest { get; set; }

        public TimeStart(int user, int session, int game, int question, int questionSet) : base(user, session)
        {
            id_game = game;
            id_quest = question;
            id_setQuest = questionSet;
        }
    }

    public class TimeReply : Event
    {
        int id_game { get; set; }
        int id_quest { get; set; }
        int id_setQuest { get; set; }
        bool correct { get; set; }

        public TimeReply(int user, int session, int game, int question, int questionSet, bool result) : base(user, session)
        {
            id_game = game;
            id_quest = question;
            id_setQuest = questionSet;
            correct = result;
        }
    }

    // OBJETIVO 2
    public class GetBlock : Event
    {
        int id_game { get; set; }
        int id_block { get; set; }

        public GetBlock(int user, int session, int game, int block) : base(user, session)
        {
            id_game = game;
            id_block = block;
        }
    }

    public class GrabBlock : Event
    {
        int id_game { get; set; }
        int id_block { get; set; }

        public GrabBlock(int user, int session, int game, int block) : base(user, session)
        {
            id_game = game;
            id_block = block;
        }
    }

    public class ReleaseBlock : Event
    {
        int id_game { get; set; }
        int id_block { get; set; }

        public ReleaseBlock(int user, int session, int game, int block) : base(user, session)
        {
            id_game = game;
            id_block = block;
        }
    }
}
