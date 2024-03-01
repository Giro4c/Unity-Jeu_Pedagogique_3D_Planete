using TMPro;

public class CurrentMonthDisplayer : InformationCycleDisplayer
{

    public string[] mois;
    /// <p>Offset for the start of the year. Is the difference of progress between 1st January (Year start)
    /// and 21st December (Winter solstice / Start of winter)</p>
    private const float _START_YEAR_OFFSET = (2f / 73f);


    public override void Display()
    {
        for (int i = 0; i < mois.Length; ++i)
        {
            float lowerBound = i / (float)mois.Length + _START_YEAR_OFFSET;
            float upperBound = (i + 1) / (float)mois.Length + _START_YEAR_OFFSET;

            if (upperBound > 1f && lowerBound < 1f)
            {
                if (valueCycle.GetProgress() >= lowerBound % 1f || valueCycle.GetProgress() <= upperBound % 1f)
                {
                    displayText.text = mois[i];
                    break;
                }
            }
            else
            {
                if (valueCycle.GetProgress() >= lowerBound % 1f && valueCycle.GetProgress() <= upperBound % 1f)
                {
                    displayText.text = mois[i];
                    break;
                }
            }
            
        }
    }
}
