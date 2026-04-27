public class ScoreChecker
{
    ScoreManager manager;
    public ScoreChecker(ScoreManager manager)
    {
        this.manager = manager;
    }

    public bool CheckPass() 
    {
        if(manager.Score>50)
            return true;
        return false;
    }
}