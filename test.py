# @Author: schwarze_falke
# @Date:   2019-02-15T01:27:29-06:00
# @Last modified by:   schwarze_falke
# @Last modified time: 2019-02-15T01:29:33-06:00
import threading
import time


def wait_for_event(e):
    while True:
        print('\tTHREAD: This is the thread speaking, we are Waiting for event\
         to start..')
        event_is_set = e.wait()
        print('\tTHREAD:  WHOOOOOO HOOOO WE GOT A SIGNAL  : %s', event_is_set)
        e.clear()


if __name__ == '__main__':
    # Main code..
    e = threading.Event()
    t = threading.Thread(name='your_mum',
                         target=wait_for_event,
                         args=(e,))
    t.start()

    while True:
        print('MAIN LOOP: still in the main loop..')
        time.sleep(4)
        print('MAIN LOOP: I just set the flag..')
        e.set()
        print('MAIN LOOP: now Im gonna do some processing n shi-t')
        time.sleep(4)
        print('MAIN LOOP:  .. some more procesing im doing   yeahhhh')
        time.sleep(4)
        print('MAIN LOOP: ok ready, soon we will repeat the loop..')
        time.sleep(2)
