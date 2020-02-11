(defblock :name start-publisher :is-top t
	(worker
		:worker-name start-publisher
		:verb "start"
		:description "Starts the publisher."
		:usage-samples (
			"pub start"))

	(end)
)
