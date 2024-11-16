using ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;
using ITMO.ObjectOrientedProgramming.Lab2.LectureModel;
using ITMO.ObjectOrientedProgramming.Lab2.SubjectModel;
using ITMO.ObjectOrientedProgramming.Lab2.UserModel;

namespace ITMO.ObjectOrientedProgramming.Lab2;

public class Updater
{
    private readonly User _user;

    public Updater(User user)
    {
        _user = user;
    }

    private abstract class Access
    {
        public abstract void UpdateLab(string newData);

        public abstract void UpdateLecture(string newData);

        public abstract void UpdateCreditSubject(IEnumerable<MaterialForLecture> lectures);

        public abstract void UpdateExamSubject(IEnumerable<MaterialForLecture> lectures);
    }

    private class Granted : Access
    {
        private readonly Labwork? _lab;
        private readonly MaterialForLecture? _lecture;
        private readonly CreditSubject? _creditSubject;

        private readonly ExamSubject? _examSubject;

        public Granted(Labwork? lab, MaterialForLecture? lecture, CreditSubject? creditSubject, ExamSubject? examSubject)
        {
            _lab = lab;
            _lecture = lecture;
            _examSubject = examSubject;
            _creditSubject = creditSubject;
        }

        public override void UpdateLab(string newData)
        {
            if (_lab != null)
            {
                _lab.AssessmentCriteria = newData;
            }
        }

        public override void UpdateLecture(string newData)
        {
            if (_lecture != null)
            {
                _lecture.Content = newData;
            }
        }

        public override void UpdateCreditSubject(IEnumerable<MaterialForLecture> lectures)
        {
            if (_creditSubject != null)
            {
                _creditSubject.Lectures = lectures;
            }
        }

        public override void UpdateExamSubject(IEnumerable<MaterialForLecture> lectures)
        {
            if (_examSubject != null)
            {
                _examSubject.Lectures = lectures;
            }
        }
    }

    private class Forbidden : Access
    {
        public override void UpdateLab(string newData)
        {
            throw new Exception("Access denied");
        }

        public override void UpdateLecture(string newData)
        {
            throw new Exception("Access denied");
        }

        public override void UpdateCreditSubject(IEnumerable<MaterialForLecture> lectures)
        {
            throw new Exception("Access denied");
        }

        public override void UpdateExamSubject(IEnumerable<MaterialForLecture> lectures)
        {
            throw new Exception("Access denied");
        }
    }

    public bool UpdateLab(Labwork lab, string newData)
    {
        try
        {
            CheckAccessToLab(lab).UpdateLab(newData);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool UpdateLecture(MaterialForLecture lecture, string newData)
    {
        try
        {
            CheckAccessToLecture(lecture).UpdateLecture(newData);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool UpdateExamSubject(ExamSubject examSubject, IEnumerable<MaterialForLecture> lectures)
    {
        try
        {
            CheckAccessToExamSubject(examSubject).UpdateExamSubject(lectures);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool UpdateCreditSubject(CreditSubject creditSubject, IEnumerable<MaterialForLecture> lectures)
    {
        try
        {
            CheckAccessToCreditSubject(creditSubject).UpdateCreditSubject(lectures);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private Access CheckAccessToLab(Labwork lab)
    {
        if (_user.Id == lab.AuthorId)
        {
            return new Granted(lab, null, null, null);
        }

        return new Forbidden();
    }

    private Access CheckAccessToLecture(MaterialForLecture lecture)
    {
        if (_user.Id == lecture.AuthorId)
        {
            return new Granted(null, lecture, null, null);
        }

        return new Forbidden();
    }

    private Access CheckAccessToExamSubject(ExamSubject examSubject)
    {
        if (_user.Id == examSubject.AuthorId)
        {
            return new Granted(null, null, null, examSubject);
        }

        return new Forbidden();
    }

    private Access CheckAccessToCreditSubject(CreditSubject creditSubject)
    {
        if (_user.Id == creditSubject.AuthorId)
        {
            return new Granted(null, null, creditSubject, null);
        }

        return new Forbidden();
    }
}
