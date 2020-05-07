import time
import datetime as dt
import tkinter
from tkinter import messagebox
import winsound

root = tkinter.Tk()
root.withdraw()

time_now = dt.datetime.now()
pom_time = 25 * 60
delta_time = dt.timedelta(0, pom_time)
end_time = time_now + delta_time
delta_sec = 5 * 60
final_time = time_now + dt.timedelta(0, pom_time + delta_sec)

total_pomodoros = 0

messagebox.showinfo("Pomodoro started!", f"Time is {time_now.strftime('%H:%M')}\n Timer set for 25 minutes.")

while True:
    if time_now < end_time:
        pass
    elif end_time <= time_now <= final_time:
        messagebox.showinfo("Break time!", f"Time is {time_now.strftime('%H:%M')}\n Break for 5 minutes.")
        time.sleep(delta_sec)
    else:
        print("\a")
        user_answer = messagebox.askyesno("Pomodoro finished!", "Do you want to start another?")
        total_pomodoros += 1
        if user_answer:
            time_now = dt.datetime.now()
            end_time = time_now + dt.timedelta(0, pom_time)
            final_time = time_now + dt.timedelta(0, pom_time + delta_sec)
            continue
        else:
            messagebox.showinfo("Pomodoro finished!", f"Time is {timenow}\n {total_pomodoros} completed today.")
            break
    time.sleep(1)
    time_now = dt.datetime.now()
    timenow = time_now.strftime("%H:%M")