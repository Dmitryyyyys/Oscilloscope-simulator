using System;
using UnityEngine;
using UnityEngine.Events;

public class OnOffButton : MonoBehaviour
{
    public Animator animator; // Анимация кнопки
    private bool isOn = true; // Состояние кнопки (включено/выключено)
    public UnityEvent onTurnOn;
    public UnityEvent onTurnOff;

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        animator.SetBool("back-on", isOn);
    }

    private void OnMouseDown()
    {
        // Переключение состояния кнопки
        isOn = !isOn;

        if (animator != null)
        {
            animator.SetBool("back-on", isOn);
        }

            // Переключаем скорость и видимость графика
            if (isOn)
            {
                onTurnOn.Invoke();
            }
            else
            {
               
                onTurnOff.Invoke();
            }
        }
    }

