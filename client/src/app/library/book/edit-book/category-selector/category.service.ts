import { Injectable } from '@angular/core';
import { Category } from '../../../models/category.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  categories: Category[] = [
    {
      id: 1,
      name: 'Romance',
      description:
        '&ensp;Indulge in tales of love, passion, and connection as characters navigate the intricate dance of emotions, weaving enchanting narratives that celebrate the enduring power of the heart.',
      icon: 'favorite',
      classNames: 'bg-rose-200 hover:bg-rose-300',
    },
    {
      id: 2,
      name: 'Fantasy',
      description:
        '&ensp;Immerse yourself in realms of magic, mythical creatures, and epic adventures where imagination knows no bounds.',
      icon: 'partly_cloudy_night',
      classNames: 'bg-purple-200 hover:bg-purple-300',
    },
    {
      id: 3,
      name: 'Action & Adventure',
      description:
        '&ensp;Brace for adrenaline-pumping narratives where courage meets chaos, and protagonists navigate perilous challenges in pursuit of excitement and triumph.',
      icon: 'sailing',
      classNames: 'bg-orange-200 hover:bg-orange-300',
    },
    {
      id: 4,
      name: 'Horror',
      description:
        '&ensp;Plunge into the chilling abyss of fear as spine-tingling tales unfold, where the unknown lurks in shadows and terror takes on countless, haunting forms.',
      icon: 'surgical',
      classNames: 'bg-slate-200 hover:bg-slate-300',
    },
    {
      id: 5,
      name: 'Detective & Mystery',
      description:
        '&ensp;Engage in riveting narratives where sleuths untangle enigmatic puzzles, solving crimes and navigating the labyrinth of suspense to uncover elusive truths.',
      icon: 'data_loss_prevention',
      classNames: 'bg-violet-200 hover:bg-violet-300',
    },
    {
      id: 6,
      name: 'Historical Fiction',
      description:
        '&ensp;Step into the past through rich narratives that blend real events with vivid imagination, offering a captivating journey into bygone eras filled with authentic characters and historical intrigue.',
      icon: 'history',
      classNames: 'bg-lime-200 hover:bg-lime-300',
    },
    {
      id: 7,
      name: 'Sci-Fi',
      description:
        '&ensp;Venture into speculative realms where science and imagination converge, unfolding futuristic landscapes, advanced technology, and thought-provoking concepts that push the boundaries of the possible.',
      icon: 'experiment',
      classNames: 'bg-indigo-200 hover:bg-indigo-300',
    },
    {
      id: 8,
      name: 'Suspense and Thrillers',
      description:
        '&ensp;Dive into gripping narratives where tension tightens, and heart-pounding twists keep you on the edge, unraveling mysteries and testing characters in a relentless pursuit of the unknown.',
      icon: 'directions_run',
      classNames: 'bg-red-200 hover:bg-red-300',
    },
    {
      id: 9,
      name: 'Essays',
      description:
        '&ensp;Thought-provoking reflections and articulate perspectives that traverse diverse topics, providing insights, analysis, and compelling narratives that resonate with the human experience.',
      icon: 'cognition',
      classNames: 'bg-teal-200 hover:bg-teal-300',
    },
    {
      id: 10,
      name: 'Biographies',
      description:
        '&ensp;Discover the real-life journeys and experiences of remarkable individuals, as these compelling narratives illuminate the triumphs, challenges, and personal growth that shape the tapestry of their lives.',
      icon: 'user_attributes',
      classNames: 'bg-green-200 hover:bg-green-300',
    },
    {
      id: 11,
      name: 'Poetry',
      description:
        '&ensp;Dive into the lyrical world of emotion and expression, where words become art, weaving poignant verses that capture the essence of human experience in all its beauty and complexity.',
      icon: 'music_note',
      classNames: 'bg-pink-200 hover:bg-pink-300',
    },
    {
      id: 12,
      name: 'Self-Help',
      description:
        '&ensp;Navigate the path to personal growth and empowerment through insightful guides and practical wisdom, offering tools and perspectives to inspire positive change and foster a journey towards a more fulfilling and balanced life.',
      icon: 'psychiatry',
      classNames: 'bg-cyan-200 hover:bg-cyan-300',
    },
    {
      id: 13,
      name: 'Children',
      description:
        '&ensp;Open the door to enchanting worlds tailored for young imaginations, where whimsical adventures, colorful characters, and timeless lessons spark the joy of discovery and foster a love for storytelling.',
      icon: 'child_care',
      classNames: 'bg-yellow-200 hover:bg-yellow-300',
    },
  ];

  constructor() {}

  getCategories() {
    return this.categories;
  }
}
