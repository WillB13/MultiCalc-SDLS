import tkinter as tk
from tkinter import messagebox
import math

# ==================================
# WINDOW
# ==================================
root = tk.Tk()
root.title("Rover Path Integral Simulator")
root.geometry("1000x800")

WIDTH = 900
HEIGHT = 650

canvas = tk.Canvas(root, width=WIDTH, height=HEIGHT, bg="white")
canvas.pack(pady=10)

# ==================================
# SIMULATION VARIABLES
# ==================================
running = False

t = 0
dt = 0.05

x_pos = 0
y_pos = 0

trail = []

vx_function = "math.cos(t)"
vy_function = "math.sin(t)"

# ==================================
# COORDINATE SYSTEM
# ==================================
scale = 50  # pixels per unit

center_x = WIDTH // 2
center_y = HEIGHT // 2

# ==================================
# DRAW AXES
# ==================================
def draw_axes():

    canvas.delete("axes")

    # x-axis
    canvas.create_line(
        0,
        center_y,
        WIDTH,
        center_y,
        fill="black",
        width=2,
        tags="axes"
    )

    # y-axis
    canvas.create_line(
        center_x,
        0,
        center_x,
        HEIGHT,
        fill="black",
        width=2,
        tags="axes"
    )

    # tick marks
    for i in range(0, WIDTH, scale):

        canvas.create_line(
            i,
            center_y - 5,
            i,
            center_y + 5,
            tags="axes"
        )

    for i in range(0, HEIGHT, scale):

        canvas.create_line(
            center_x - 5,
            i,
            center_x + 5,
            i,
            tags="axes"
        )

# ==================================
# CONVERT MATH TO SCREEN
# ==================================
def screen_x(x):
    return center_x + x * scale

def screen_y(y):
    return center_y - y * scale

# ==================================
# START
# ==================================
def start():

    global running
    global vx_function
    global vy_function

    try:
        vx_function = vx_entry.get()
        vy_function = vy_entry.get()

        # quick validation
        eval(vx_function,
             {"math": math},
             {"t": 0})

        eval(vy_function,
             {"math": math},
             {"t": 0})

    except Exception:
        messagebox.showerror(
            "Error",
            "Invalid velocity function."
        )
        return

    running = True

# ==================================
# STOP
# ==================================
def stop():

    global running
    running = False

# ==================================
# RESET
# ==================================
def reset():

    global running
    global t
    global x_pos
    global y_pos
    global trail

    running = False

    t = 0
    x_pos = 0
    y_pos = 0

    trail = []

    canvas.delete("all")
    draw_axes()

    update_rover()

# ==================================
# DRAW ROVER
# ==================================
def update_rover():

    canvas.delete("rover")

    sx = screen_x(x_pos)
    sy = screen_y(y_pos)

    canvas.create_oval(
        sx - 8,
        sy - 8,
        sx + 8,
        sy + 8,
        fill="red",
        tags="rover"
    )

# ==================================
# SIMULATION LOOP
# ==================================
def simulate():

    global t
    global x_pos
    global y_pos

    if running:

        try:

            vx = eval(
                vx_function,
                {"math": math},
                {"t": t}
            )

            vy = eval(
                vy_function,
                {"math": math},
                {"t": t}
            )

            # Numerical integration
            x_pos += vx * dt
            y_pos += vy * dt

            sx = screen_x(x_pos)
            sy = screen_y(y_pos)

            trail.append((sx, sy))

            if len(trail) > 1:

                x1, y1 = trail[-2]
                x2, y2 = trail[-1]

                canvas.create_line(
                    x1,
                    y1,
                    x2,
                    y2,
                    fill="blue",
                    width=2
                )

            update_rover()

            info_label.config(
                text=
                f"t = {t:.2f}     "
                f"x = {x_pos:.2f}     "
                f"y = {y_pos:.2f}"
            )

            t += dt

        except Exception:
            pass

    root.after(20, simulate)

# ==================================
# CONTROL PANEL
# ==================================
controls = tk.Frame(root)
controls.pack()

tk.Label(
    controls,
    text="vx(t)"
).grid(row=0, column=0)

vx_entry = tk.Entry(
    controls,
    width=25
)
vx_entry.grid(row=0, column=1)
vx_entry.insert(0, "math.cos(t)")

tk.Label(
    controls,
    text="vy(t)"
).grid(row=1, column=0)

vy_entry = tk.Entry(
    controls,
    width=25
)
vy_entry.grid(row=1, column=1)
vy_entry.insert(0, "math.sin(t)")

tk.Button(
    controls,
    text="Start",
    command=start,
    width=12
).grid(row=0, column=2, padx=10)

tk.Button(
    controls,
    text="Stop",
    command=stop,
    width=12
).grid(row=1, column=2, padx=10)

tk.Button(
    controls,
    text="Reset",
    command=reset,
    width=12
).grid(row=2, column=2, padx=10)

info_label = tk.Label(
    root,
    text="",
    font=("Arial", 14)
)
info_label.pack(pady=10)

# ==================================
# INIT
# ==================================
draw_axes()
update_rover()
simulate()

root.mainloop()