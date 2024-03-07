using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Visuals.Seasons
{

    public class WeatherChanger : MonoBehaviour
    {
        [SerializeField] private GameObject snow;
        [SerializeField] private GameObject rain;
        [SerializeField] private AudioClip soundRain;

        private AudioSource _source;

        [SerializeField] private SeasonChanger seasons;
        private Season _season = Season.Winter;

        // Start is called before the first frame update
        void Awake()
        {
            gameObject.AddComponent<AudioSource>();
            _source = GetComponent<AudioSource>();
        }

        void Start()
        {
            SetUp();
            StartCoroutine(ChangeWeather());
        }

        private void SetUp()
        {
            _season = seasons.season;
            _source.clip = soundRain;
            SetWeather(seasons.season);
        }

        private void SetAll()
        {
            _season = seasons.season;
            SetWeather(seasons.season);
        }

        IEnumerator ChangeWeather()
        {
            while (enabled)
            {
                if (!_season.Equals(seasons.season))
                {
                    SetAll();
                    //print("Changement effectué.");
                }

                yield return null;
            }

        }

        private void SetWeather(Season season)
        {
            if (season.Equals(Season.Winter))
            {
                snow.SetActive(true);
                rain.SetActive(false);
                _source.Pause();
            }
            else if (season.Equals(Season.Fall))
            {
                rain.SetActive(true);
                snow.SetActive(false);
                if (!_source.isPlaying)
                {
                    _source.Play();
                }
            }
            else
            {
                rain.SetActive(false);
                snow.SetActive(false);
                _source.Pause();
            }
        }

    }

}