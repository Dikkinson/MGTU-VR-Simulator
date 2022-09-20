using System.Threading.Tasks;

public class Timer
{
    private float waitTime;

    public float WaitTime => waitTime;

	public Timer(float _waitTime)
	{
		waitTime = _waitTime;
	}

	public async Task Start()
	{
		await Task.Delay((int)(waitTime * 1000));
	}
}
