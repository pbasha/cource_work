using GOLDEN_MANAGER.Models;
using System.Collections.Generic;
using System.Linq;

namespace GOLDEN_MANAGER.Data
{
    public class ManagerDBRepository
    {
        #region constructor

        public ManagerDBRepository()
        {
            context = new ManagerDBContext();
        }

        #endregion

        #region private filds

        private ManagerDBContext context;

        #endregion

        #region Tasks

        public Task AddTask(Task item)
        {
            context.Tasks.Add(item);
            context.SaveChanges();
            return item;
        }

        public Task GetTaskById(int task_id)
        {
            return context.Tasks.Where(r => r.task_id == task_id).FirstOrDefault();
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return context.Tasks;          
        }

        public void DeleteTask(int task_id)
        {
            Task item = GetTaskById(task_id);
            if (item != null)
            {
                context.Tasks.Remove(item);
                context.SaveChanges();
            }
        }

        public bool UpdateTask(Task item)
        {
            Task storedItem = GetTaskById(item.task_id);

            if (storedItem != null)
            {
                storedItem.task_id = item.task_id;
                storedItem.task_name = item.task_name;
                storedItem.task_description = item.task_description;
                storedItem.task_priority = item.task_priority;
                storedItem.task_achiv_points = item.task_achiv_points;
                storedItem.user = item.user;

                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Bonuses

        public Bonus AddBonus(Bonus item)
        {
            context.Bonuses.Add(item);
            context.SaveChanges();
            return item;
        }

        public Bonus GetBonusById(int Bonus_id)
        {
            return context.Bonuses.Where(r => r.bonus_id == Bonus_id).FirstOrDefault();
        }

        public IEnumerable<Bonus> GetAllBonuses()
        {
            return context.Bonuses;
        }

        public void DeleteBonus(int Bonus_id)
        {
            Bonus item = GetBonusById(Bonus_id);
            if (item != null)
            {
                context.Bonuses.Remove(item);
                context.SaveChanges();
            }
        }

        public bool UpdateBonus(Bonus item)
        {
            Bonus storedItem = GetBonusById(item.bonus_id);

            if (storedItem != null)
            {
                storedItem.bonus_id = item.bonus_id;
                storedItem.bonus_name = item.bonus_name;
                storedItem.bonus_description = item.bonus_description;
                storedItem.bonus_points_must_achieve = item.bonus_points_must_achieve;
                storedItem.user = item.user;

                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region skills

        public Skill AddSkill(Skill item)
        {
            context.Skills.Add(item);
            context.SaveChanges();
            return item;
        }

        public Skill GetSkillById(int skill_id)
        {
            return context.Skills.Where(r => r.skill_id == skill_id).FirstOrDefault();
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            return context.Skills;
        }

        public void DeleteSkill(int skill_id)
        {
            Skill item = GetSkillById(skill_id);
            if (item != null)
            {
                context.Skills.Remove(item);
                context.SaveChanges();
            }
        }

        public bool UpdateSkill(Skill item)
        {
            Skill storedItem = GetSkillById(item.skill_id);

            if (storedItem != null)
            {
                storedItem.skill_id = item.skill_id;
                storedItem.skill_name = item.skill_name;
                storedItem.skill_lvl = item.skill_lvl;
                storedItem.user = item.user;
                storedItem.skill_points = item.skill_points;

                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Notes

        public Note AddNote(Note item)
        {
            context.Notes.Add(item);
            context.SaveChanges();
            return item;
        }

        public Note GetNoteById(int note_id)
        {
            return context.Notes.Where(r => r.note_id == note_id).FirstOrDefault();
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return context.Notes;
        }

        public void DeleteNote(int note_id)
        {
            Note item = GetNoteById(note_id);
            if (item != null)
            {
                context.Notes.Remove(item);
                context.SaveChanges();
            }
        }

        public bool UpdateNotes(Note item)
        {
            Note storedItem = GetNoteById(item.note_id);

            if (storedItem != null)
            {
                storedItem.note_id = item.note_id;
                storedItem.note_name = item.note_name;
                storedItem.note_description = item.note_description;
                storedItem.note_priority = item.note_priority;
                storedItem.user = item.user;
                storedItem.group_notes_id = item.group_notes_id;

                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region User

        public User AddUser(User item)
        {
            context.Users.Add(item);
            context.SaveChanges();
            return item;
        }

        public User GetUserById(int user_id)
        {
            return context.Users.Where(r => r.user_id == user_id).FirstOrDefault();
        }

        public User GetUserByEmail(string user_email)
        {
            return context.Users.Where(r => r.user_email == user_email).FirstOrDefault();
        }

        #endregion

        #region Days

        public Day AddDay(Day item)
        {
            context.Days.Add(item);
            context.SaveChanges();
            return item;
        }

        public Day GetDayById(int day_id)
        {
            return context.Days.Where(r => r.day_id == day_id).FirstOrDefault();
        }

        public IEnumerable<Day> GetAllDays()
        {
            return context.Days;
        }

        #endregion

        #region Motivation

        public Motivation Addmotivation(Motivation item)
        {
            context.Motiations.Add(item);
            context.SaveChanges();
            return item;
        }

        public Motivation GetMotivationById(int mot_id)
        {
            return context.Motiations.Where(r => r.mot_id == mot_id).FirstOrDefault();
        }

        public IEnumerable<Motivation> GetAllMots()
        {
            return context.Motiations;
        }

        #endregion
    }
}